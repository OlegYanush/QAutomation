namespace QAutomation.Selenium.Support.PageObjects
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using Unity;

    public class QAutomationPageMemberObjectDecorator : IPageObjectMemberDecorator
    {
        private static List<Type> _interfacesToBeProxied;
        private static Type _interfaceProxyType;

        private static List<Type> InterfacesToBeProxied
        {
            get
            {
                if (_interfacesToBeProxied == null)
                    _interfacesToBeProxied = new List<Type> { typeof(IUiElement) };

                return _interfacesToBeProxied;
            }
        }

        private static Type InterfaceToBeProxied => typeof(IUiElement);
        private static Type InterfaceProxyType
        {
            get
            {
                if (_interfaceProxyType == null)
                {
                    _interfaceProxyType = CreateTypeForASingleElement();
                }

                return _interfaceProxyType;
            }
        }

        private IUnityContainer _container;

        public QAutomationPageMemberObjectDecorator(IUnityContainer container)
        {
            _container = container;
        }

        public object Decorate(MemberInfo member, IElementLocator locator)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;

            Type targetType = null;
            if (field != null)
            {
                targetType = field.FieldType;
            }

            bool hasPropertySet = false;
            if (property != null)
            {
                hasPropertySet = property.CanWrite;
                targetType = property.PropertyType;
            }

            if (field == null & (property == null || !hasPropertySet))
            {
                return null;
            }

            IList<Locator> locators = CreateLocatorList(member);

            if (locators.Count > 0)
            {
                bool cache = ShouldCacheLookup(member);
                object proxyObject = CreateProxyObject(targetType, locator, locators, _container, cache);
                return proxyObject;
            }

            return null;
        }

        private IList<Locator> CreateLocatorList(MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member", "memeber cannot be null");
            }

            List<Locator> locators = new List<Locator>();

            var attributes = Attribute.GetCustomAttributes(member, typeof(QAutomationFindByAttribute), true);
            if (attributes.Length > 0)
            {
                Array.Sort(attributes);
                foreach (var attribute in attributes)
                {
                    var castedAttribute = (QAutomationFindByAttribute)attribute;
                    if (castedAttribute.Using == null)
                    {
                        castedAttribute.Using = member.Name;
                    }

                    locators.Add(castedAttribute.Locator);
                }
            }

            return locators.AsReadOnly();
        }

        private static Type CreateTypeForASingleElement()
        {
            AssemblyName tempAssemblyName = new AssemblyName(Guid.NewGuid().ToString());

            AssemblyBuilder dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(tempAssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = dynamicAssembly.DefineDynamicModule(tempAssemblyName.Name);
            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeof(IUiElement).FullName, TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);

            foreach (Type type in InterfacesToBeProxied)
            {
                typeBuilder.AddInterfaceImplementation(type);
            }

            return typeBuilder.CreateType();
        }

        private static object CreateProxyObject(Type memberType, IElementLocator locator, IEnumerable<Locator> locators, IUnityContainer container, bool cache)
        {
            MethodInfo method = null;

            if (memberType.IsGenericType)
            {
                var genericTypeDef = memberType.GetGenericTypeDefinition();

                if (genericTypeDef.Equals(typeof(IList<>)) || genericTypeDef.IsAssignableFrom(typeof(IList<>)))
                {
                    var arguments = memberType.GetGenericArguments();

                    if (arguments.Length == 1
                        && (arguments[0].Equals(InterfaceToBeProxied) || InterfaceToBeProxied.IsAssignableFrom(arguments[0])))
                    {
                        var proxyType = typeof(UiElementListProxy<>).MakeGenericType(arguments[0]);
                        method = proxyType.GetMethod("CreateProxy", BindingFlags.Public | BindingFlags.Static);
                    }
                }
            }
            else if (memberType.GetInterface(nameof(IUiElement)) != null || memberType.IsAssignableFrom(InterfaceToBeProxied))
            {
                var proxyType = typeof(UiElementProxy<>).MakeGenericType(memberType);
                method = proxyType.GetMethod("CreateProxy", BindingFlags.Public | BindingFlags.Static);
            }
            else
                return null;

            return method.Invoke(null, new object[] { memberType, locators, locator.SearchContext, container, cache });
        }

        protected static bool ShouldCacheLookup(MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException("member", "memeber cannot be null");

            var cacheAttributeType = typeof(CacheLookupAttribute);
            bool cache = member.GetCustomAttributes(cacheAttributeType, true).Length != 0 || member.DeclaringType.GetCustomAttributes(cacheAttributeType, true).Length != 0;
            return cache;
        }
    }
}

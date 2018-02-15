namespace QAutomation.Selenium.Support.PageObjects
{
    using OpenQA.Selenium.Support.PageObjects;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class QAutomationPageMemberObjectDecorator : IPageObjectMemberDecorator
    {
        private static Type InterfaceToBeProxied => typeof(IUiElement);

        public object Decorate(MemberInfo member, IElementLocator locator)
        {
            var castedLocator = locator as IUiElementLocator;

            if (castedLocator == null)
                throw new ArgumentException($"{GetType().Name}.{nameof(IPageObjectMemberDecorator.Decorate)} method requires {nameof(IUiElementLocator)} lcoator type");

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
                object proxyObject = CreateProxyObject(targetType, castedLocator, locators, cache);
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

        private static object CreateProxyObject(Type memberType, IUiElementLocator locator, IEnumerable<Locator> locators, bool cache)
        {
            MethodInfo method = null;

            if (memberType.IsGenericType)
            {
                var genericTypeDef = memberType.GetGenericTypeDefinition();

                if (genericTypeDef.Equals(typeof(IList<>)))
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
            else if (memberType.IsInterface &&
                        (memberType.GetInterface(InterfaceToBeProxied.Name) != null || memberType.IsAssignableFrom(InterfaceToBeProxied)))
            {
                var proxyType = typeof(UiElementProxy<>).MakeGenericType(memberType);
                method = proxyType.GetMethod("CreateProxy", BindingFlags.Public | BindingFlags.Static);
            }
            else
                throw new ArgumentException($"Type of member '{memberType.Name}' isn't IList<{InterfaceToBeProxied.Name}>,{InterfaceToBeProxied.Name} or derived interface.");

            return method.Invoke(null, new object[] { memberType, locators, locator, cache });
        }

        protected static bool ShouldCacheLookup(MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "memeber cannot be null");

            var cacheAttributeType = typeof(CacheLookupAttribute);

            bool cache = member.GetCustomAttributes(cacheAttributeType, true).Length != 0
                      || member.DeclaringType.GetCustomAttributes(cacheAttributeType, true).Length != 0;

            return cache;
        }
    }
}

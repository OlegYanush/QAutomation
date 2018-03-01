namespace QAutomation.Core.Support.PageObjects
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class DefaultPageObjectDecorator : IPageObjectDecorator
    {
        private const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
        private const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;


        private static List<Type> _interfacesToBeProxied;
        private static Type InterfaceToBeProxied => typeof(IUiElement);

        private static IList<Locator> CreateLocatorList(MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "member cannot be null");

            List<Locator> locators = new List<Locator>();

            var attributes = Attribute.GetCustomAttributes(member, typeof(LocateByAttribute), true);
            if (attributes.Length > 0)
            {
                Array.Sort(attributes);
                foreach (var attribute in attributes)
                {
                    var castedAttribute = (LocateByAttribute)attribute;

                    if (castedAttribute.Using == null)
                        castedAttribute.Using = member.Name;

                    locators.Add(castedAttribute.Locator);
                }
            }

            return locators.AsReadOnly();
        }

        private static List<MemberInfo> GetPageObjectMembers(object pageObject)
        {
            var members = new List<MemberInfo>();
            var type = pageObject.GetType();

            members.AddRange(type.GetFields(PublicBindingOptions));
            members.AddRange(type.GetProperties(PublicBindingOptions));

            while (type != null)
            {
                members.AddRange(type.GetFields(NonPublicBindingOptions));
                members.AddRange(type.GetProperties(NonPublicBindingOptions));
                type = type.BaseType;
            }

            return members.Where(m => IsPageObjectMember(m)).ToList();
        }

        public void Decorate(IUiElementLocator locator, object page)
        {
            var dict = new Dictionary<MemberInfo, bool>();
            var members = GetPageObjectMembers(page);

            members.ForEach(m => dict.Add(m, false));

            var pageObjectType = page.GetType();
            int attempts = 3;

            while (dict.Any(m => !m.Value) && attempts > 0)
            {
                foreach (var member in members)
                {
                    if (dict[member]) continue;

                    var locatedOfAttribute = member.GetCustomAttribute<LocatedOfAttribute>(true);

                    if (locatedOfAttribute != null)
                    {
                        var parentMember = members.SingleOrDefault(m => m.Name.Equals(locatedOfAttribute.Member));
                        var targetParentMemberType = GetTargetType(parentMember);

                        if (!InterfaceToBeProxied.IsAssignableFrom(targetParentMemberType))
                            throw new Exception($"Page object '{pageObjectType}' doesn't have allowable member '{locatedOfAttribute.Member}'.");

                        IUiElement parent = null;

                        var property = parentMember as PropertyInfo;
                        var field = parentMember as FieldInfo;

                        if (property != null)
                            parent = property.GetValue(page) as IUiElement;
                        if (field != null)
                            parent = field.GetValue(page) as IUiElement;

                        if (parent != null)
                        {
                            SetProxyToPageObject(member, locator, page, parent);
                            dict[member] = true;
                        }
                    }
                    else
                    {
                        SetProxyToPageObject(member, locator, page);
                        dict[member] = true;
                    }
                }
                attempts--;
            }

            if (dict.Any(m => !m.Value))
                throw new Exception($"Page object '{pageObjectType}' has looping elements or uninitialized members.");
        }

        private static void SetProxyToPageObject(MemberInfo member, IUiElementLocator locator, object pageObject, IUiElement parent = null)
        {
            var locators = CreateLocatorList(member);

            if (locators.Count > 0)
            {
                bool cache = ShouldCacheLookup(member);
                var proxyObject = CreateProxyObject(GetTargetType(member), locator, locators, cache, parent);

                var field = member as FieldInfo;
                var property = member as PropertyInfo;

                if (field != null)
                    field.SetValue(pageObject, proxyObject);

                if (property != null)
                    property.SetValue(pageObject, proxyObject, null);
            }
        }

        private static object CreateProxyObject(Type memberType, IUiElementLocator locator, IEnumerable<Locator> locators, bool cache, IUiElement parent = null)
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
                throw new ArgumentException($"Type of member '{memberType.Name}' isn't a IList<{InterfaceToBeProxied.Name}>,{InterfaceToBeProxied.Name} or derived interface.");

            return method.Invoke(null, new object[] { memberType, locators, locator, cache, parent });
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

        protected static Type GetTargetType(MemberInfo member)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;

            return property != null
                ? property.PropertyType
                : (field != null ? field.FieldType : throw new ArgumentException($"page object member '{member}' must be a field or preperty.", nameof(member)));
        }
        protected static bool IsPageObjectMember(MemberInfo member)
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

            return !(field == null & (property == null || !hasPropertySet));
        }
    }
}

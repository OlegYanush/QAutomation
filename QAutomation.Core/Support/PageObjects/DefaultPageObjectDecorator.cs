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
        private static Type InterfaceToBeProxied => typeof(IUiElement);

        private static IList<Locator> CreateLocatorList(MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "member cannot be null");

            List<Locator> locators = new List<Locator>();

            var attributes = Attribute.GetCustomAttributes(member, typeof(SearchByAttribute), true);
            if (attributes.Length > 0)
            {
                Array.Sort(attributes);
                foreach (var attribute in attributes)
                {
                    var castedAttribute = (SearchByAttribute)attribute;

                    if (castedAttribute.Using == null)
                        castedAttribute.Using = member.Name;

                    locators.Add(castedAttribute.Locator);
                }
            }

            return locators.AsReadOnly();
        }

        private static IEnumerable<MemberInfo> GetPageObjectMembers(object pageObject)
        {
            const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
            const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;

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

            return members.Where(m => IsValidMember(m));
        }

        public void Decorate(IUiElementLocator locator, object page)
        {
            var members = GetPageObjectMembers(page);
            var dict = new Dictionary<MemberInfo, bool>();

            members.ToList().ForEach(m => dict.Add(m, false));

            while (dict.Any(m => !m.Value))
            {
                foreach (var member in members)
                {
                    if (dict[member]) continue;

                    if (HasUnresolvedParent(member, page))
                        continue;
                    else
                    {
                        IList<Locator> locators = CreateLocatorList(member);

                        if (locators.Count > 0)
                        {
                            bool cache = ShouldCacheLookup(member);
                            object proxyObject = CreateProxyObject(GetTargetType(member), locator, locators, cache);

                            var searchFromAttr = member.GetCustomAttribute<LocatedOfAttribute>(true);

                            if (searchFromAttr != null)
                            {
                                var prop = member.DeclaringType.GetProperty(searchFromAttr.Property);
                                var value = prop.GetValue(page);

                                var locatorParentProp = typeof(Locator).GetProperty(nameof(Locator.ParentElement));

                                locators.ToList().ForEach(l => locatorParentProp.SetValue(l, value));
                            }

                            var field = member as FieldInfo;
                            var property = member as PropertyInfo;

                            if (field != null)
                                field.SetValue(page, proxyObject);

                            if (property != null)
                                property.SetValue(page, proxyObject, null);

                            dict[member] = true;
                        }
                        else
                            dict[member] = true;
                    }
                }
            }
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
                throw new ArgumentException($"Type of member '{memberType.Name}' isn't a IList<{InterfaceToBeProxied.Name}>,{InterfaceToBeProxied.Name} or derived interface.");

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

        protected static bool HasUnresolvedParent(MemberInfo member, object page)
        {
            var searchFromAttribute = member.GetCustomAttribute<LocatedOfAttribute>(true);

            if (searchFromAttribute != null)
            {
                var type = page.GetType();

                var findedProperty = type.GetProperty(searchFromAttribute.Property);
                var findedField = type.GetField(searchFromAttribute.Property);

                if (findedField == null && findedProperty == null)
                    throw new ArgumentException($"Page object with type '{type.Name}' doesn't have field or preperty '{searchFromAttribute.Property}'");

                object value = null;

                if (findedProperty != null)
                    value = findedProperty.GetValue(page);

                if (findedField != null)
                    value = findedField.GetValue(page);

                return value == null;
            }

            return false;
        }

        protected static object InitializePageObjectMember(Type memberType, IUiElementLocator locator)
        {
            var locators = CreateLocatorList(memberType);

            if (locators.Count > 0)
            {
                bool cache = ShouldCacheLookup(memberType);
                object proxyObject = CreateProxyObject(GetTargetType(memberType), locator, locators, cache);
            }

            return null;
        }

        protected static MemberInfo TryToGetUninitializedParentMember(MemberInfo childMember, object page)
        {
            var searchFromAttribute = childMember.GetCustomAttribute<LocatedOfAttribute>(true);

            if (searchFromAttribute != null)
            {
                var parentMemberProperty = page.GetType().GetProperty(searchFromAttribute.Property);

                var value = parentMemberProperty.GetValue(page);
                return value == null ? parentMemberProperty : null;
            }

            return null;
        }

        protected static Type GetTargetType(MemberInfo member)
        {
            FieldInfo field = member as FieldInfo;
            PropertyInfo property = member as PropertyInfo;

            return property != null
                ? property.PropertyType
                : (field != null ? field.FieldType : throw new ArgumentException("member must be a field or preperty.", nameof(member)));
        }
        protected static bool IsValidMember(MemberInfo member)
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

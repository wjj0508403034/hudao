using System;

namespace Google.Material.Extensions
{
    public static class EnumExtension
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length == 0)
            {
                return null;
            }

            var attrs = memberInfo[0].GetCustomAttributes(typeof(T), true);
            if (attrs.Length > 0)
            {
                return (T)attrs[0];
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace hudao.Core.Enums
{
    public class EnumConverter : IValueConverter
    {
        private static Dictionary<Type,ObservableCollection<EnumItem>> cache = new Dictionary<Type, ObservableCollection<EnumItem>>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumType = (Type) value;
            if(cache.ContainsKey(enumType))
            {
                return cache[enumType];
            }

            var items = new ObservableCollection<EnumItem>();
            if (enumType.IsEnum)
            {
                foreach (var enumItem in enumType.GetEnumValues())
                {
                    var displayAttr = this.getAttr(enumType, enumItem);
                    if(!displayAttr.Hidden)
                    {
                        items.Add(new EnumItem(displayAttr, enumItem));
                    }  
                }
            }

            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private  DisplayAttribute getAttr(Type enumType, object enumField)
        {
            var memberInfo = enumType.GetMember(enumField.ToString());
            if (memberInfo.Length == 0)
            {
                return null;
            }
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attrs.Length > 0)
            {
                return (DisplayAttribute)attrs[0];
            }
            return null;
        }
    }
}

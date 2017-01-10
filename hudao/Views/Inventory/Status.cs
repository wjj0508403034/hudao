using System;
using System.Collections.Generic;
using hudao.Core.Enums;

namespace hudao.Views.Inventory
{
    public enum Status
    {
        [Display(Text = "未处理")]
        New,

        [Display(Text = "正在处理")]
        InProgress,

        [Display(Text = "已结束")]
        Finish
    }


    public static class EnumExtension
    {
        public static List<string> GetEnumItems(Enum _enum)
        {
            return new List<string>();
        }
    }
}

using System.ComponentModel;
using Google.Material.Extensions;

namespace Google.Material.Icons
{
    /// <summary>
    /// https://material.io/icons
    /// </summary>
    public enum Icon
    {
        None,
        [Category("Alert Icons"), Description("Error"), Id("error")]
        Error,

        [Category("Alert Icons"), Description("Warning"), Id("warning")]
        Warning,

        [Category("Navigation Icons"), Description("Check"), Id("check")]
        Check,

        [Category("Toggle Icons"), Description("Check Box checked"), Id("check_box")]
        CheckBoxChecked,

        [Category("Toggle Icons"), Description("Check Box Unchecked"), Id("check_box_outline_blank")]
        CheckBoxUnChecked
    }

    public static class IconExtension
    {
        public static string GetIdValue(this Icon icon)
        {
            var attr = icon.GetAttribute<IdAttribute>();
            return attr != null ? attr.Id : null;
        }
    }
}

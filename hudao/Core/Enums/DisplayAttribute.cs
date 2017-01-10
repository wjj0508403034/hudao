using System;

namespace hudao.Core.Enums
{
    public class DisplayAttribute : Attribute
    {
        public string Text { get; set; }
        public bool Hidden { get; set; }
    }
}

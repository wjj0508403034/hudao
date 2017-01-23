using System;

namespace Google.Material.Icons
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = true, Inherited = false)]
    public class CategoryAttribute : Attribute
    {
        public string Category { get; set; }


        public CategoryAttribute(string category)
        {
            this.Category = category;
        }
    }
}

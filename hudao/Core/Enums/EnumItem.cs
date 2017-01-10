namespace hudao.Core.Enums
{
    public class EnumItem
    {
        public string DisplayName { get; set; }
        public object Value { get; set; }

        public EnumItem(DisplayAttribute attr,object value)
        {
            this.DisplayName = attr.Text;
            this.Value = value;
        }
    }
}

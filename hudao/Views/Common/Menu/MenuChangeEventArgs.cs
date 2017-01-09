namespace hudao.Views.Common.Menu
{
    public class MenuChangeEventArgs
    {
        public MenuItem OldMenuItem { get; private set; }
        public MenuItem NewMenuItem { get; private set; }

        public MenuChangeEventArgs(MenuItem oldMenuItem,MenuItem newMenuItem)
        {
            this.OldMenuItem = oldMenuItem;
            this.NewMenuItem = newMenuItem;
        }
    }
}

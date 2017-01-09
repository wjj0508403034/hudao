using System.ComponentModel;
using System.Windows.Input;
using hudao.Core.EventHandlers;

namespace hudao.Views.Common.Menu
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar
    {
        public MenuBar()
        {
            InitializeComponent();
            this.MenuItemChanged += this.MenuItem1.OnMenuItemChanged;
            this.MenuItemChanged += this.MenuItem2.OnMenuItemChanged;
            this.MenuItemChanged += this.MenuItem3.OnMenuItemChanged;
            this.MenuItemChanged += this.MenuItem4.OnMenuItemChanged;
        }

        public MenuItem SelectedMenuItem { get; private set; }
        private MenuItemChangeEventHandler menuItemChanged;

        [Category("Behavior")]
        public event MenuItemChangeEventHandler MenuItemChanged
        {
            add
            {
                menuItemChanged += value;
            }
            remove
            {
                menuItemChanged -= value;
            }
        }

        private void OnMenuItemClicked(MenuItem menuItem, MouseButtonEventArgs e)
        {
            var oldMenuItem = this.SelectedMenuItem;
            this.SelectedMenuItem = menuItem;
            if (this.menuItemChanged != null)
            {
                this.menuItemChanged(this, new MenuChangeEventArgs(oldMenuItem, menuItem));
            }
        }
    }
}

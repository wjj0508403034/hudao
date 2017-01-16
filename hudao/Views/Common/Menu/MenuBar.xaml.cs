using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
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
        }
        private static readonly double AnimationDuration = 0.5;
        public MenuItem SelectedMenuItem { get; private set; }
        private delegate void MenuCloseEventHandler();
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

        public bool IsOpen
        {
            get { return this.Visibility == Visibility.Visible; }
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
            var ta = new ThicknessAnimation();
            ta.From = new Thickness(-this.Width, 0, 0, 0); 
            ta.To = new Thickness(0, 0, 0, 0); 
            ta.Duration = TimeSpan.FromSeconds(AnimationDuration);  
            this.BeginAnimation(MarginProperty, ta);
        }

        public void Close()
        {
            var ta = new ThicknessAnimation();
            ta.Completed += OnMenuAnimationClosed;
            ta.From = new Thickness(0, 0, 0, 0); 
            ta.To = new Thickness(-this.Width, 0, 0, 0);
            ta.Duration = TimeSpan.FromSeconds(AnimationDuration);
            this.BeginAnimation(MarginProperty, ta);
        }

        private void OnMenuAnimationClosed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new MenuCloseEventHandler(this.OnMenuClose));
        }

        private void OnMenuClose()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void OnMenuItemClicked(MenuItem menuItem, MouseButtonEventArgs e)
        {
            if (!menuItem.IsBindedMenuItemChangedEvent)
            {
                menuItem.IsBindedMenuItemChangedEvent = true;
                this.MenuItemChanged += menuItem.OnMenuItemChanged;
            }
            var oldMenuItem = this.SelectedMenuItem;
            this.SelectedMenuItem = menuItem;
            if (this.menuItemChanged != null)
            {
                this.menuItemChanged(this, new MenuChangeEventArgs(oldMenuItem, menuItem));
            }
        }
    }
}

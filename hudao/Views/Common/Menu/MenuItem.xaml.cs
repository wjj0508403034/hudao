using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using hudao.Core.EventHandlers;

namespace hudao.Views.Common.Menu
{
    /// <summary>
    /// Interaction logic for MenuItem.xaml
    /// </summary>
    public partial class MenuItem
    {
        public MenuItem()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsSelectedProperty =
         DependencyProperty.Register(
                 "IsSelected",
                 typeof(bool),
                 typeof(MenuItem),
                 new FrameworkPropertyMetadata(
                         false,
                         new PropertyChangedCallback(OnIsSelectedChanged)));

        [Bindable(true)]
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }


        public object Icon
        {
            get { return this.IconContentPresenter.Content; }
            set { this.IconContentPresenter.Content = value; }
        }

        public object MenuContent
        {
            get { return this.ContentPresenter.Content; }
            set { this.ContentPresenter.Content = value; }
        }

        public VerticalAlignment MenuContentVerticalAlignment
        {
            get { return this.ContentPresenter.VerticalAlignment; }
            set { this.ContentPresenter.VerticalAlignment = value; }
        }

        private MenuItemClickEventHandler menuItemClicked;

        [Category("Behavior")]
        public event MenuItemClickEventHandler MenuItemClicked
        {
            add
            {
                menuItemClicked += value;
            }
            remove
            {
                menuItemClicked -= value;
            }
        }

        public bool IsBindedMenuItemChangedEvent { get; set; }

        public void OnMenuItemChanged(MenuBar menuBar, MenuChangeEventArgs e)
        {
            this.IsSelected = e.NewMenuItem == this;
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void OnMenuItemClick(object sender, MouseButtonEventArgs e)
        {
            if (this.menuItemClicked != null)
            {
                this.menuItemClicked(this, e);
            }
        }
    }
}

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hudao.Views.Common.Menu
{
    /// <summary>
    /// Interaction logic for MenuGroup.xaml
    /// </summary>
    public partial class MenuGroup
    {
        public MenuGroup()
        {
            InitializeComponent();
       
        }

        public static readonly DependencyProperty ExpandProperty =
        DependencyProperty.Register(
                "Expand",
                typeof(bool),
                typeof(MenuGroup),
                new FrameworkPropertyMetadata(
                        false,
                        new PropertyChangedCallback(OnExpandChanged)));

        [Bindable(true)]
        public bool Expand
        {
            get { return (bool)GetValue(ExpandProperty); }
            set { SetValue(ExpandProperty, value); }
        }

        public UIElementCollection Children
        {
            get { return this.MenuItemsPanel.Children; }
        }

        public object GroupHeaderIcon
        {
            get { return this.GroupHeaderContentPresenter.Content; }
            set { this.GroupHeaderIconContentPresenter.Content = value; }
        }

        public object GroupHeaderContent
        {
            get { return this.GroupHeaderContentPresenter.Content; }
            set { this.GroupHeaderContentPresenter.Content = value; }
        }

        public VerticalAlignment GroupHeaderContentVerticalAlignment
        {
            get { return this.GroupHeaderContentPresenter.VerticalAlignment; }
            set { this.GroupHeaderContentPresenter.VerticalAlignment = value; }
        }

        private static void OnExpandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var group = (MenuGroup) d;
            group.MenuItemsPanel.Visibility = group.Expand ? Visibility.Visible : Visibility.Collapsed;
        }

        private void OnMeunGroupHeaderClick(object sender, MouseButtonEventArgs e)
        {
            this.Expand = !this.Expand;
        }
    }
}

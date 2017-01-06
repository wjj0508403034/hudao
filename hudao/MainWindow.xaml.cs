using System.Windows;
using hudao.Core;
using hudao.Views.MemberShip.Index;
using hudao.Views.SalesReturn.Create;

namespace hudao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.Current.GotoView(new CreateView());
        }

        public Visibility MenuVisibility
        {
            get { return this.MenuBar.Visibility; }
            set { this.MenuBar.Visibility = value; }
        }

        public object ViewContent
        {
            get { return this.ViewContainer.Content; }
            set { this.ViewContainer.Content = value; }
        }

        public void AddMessage(UIElement element)
        {
            this.MessageContainer.Children.Add(element);
        }

        public void RemoveMessage(UIElement element)
        {
            this.MessageContainer.Children.Remove(element);
        }
    }
}

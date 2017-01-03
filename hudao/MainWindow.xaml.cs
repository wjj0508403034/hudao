using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using hudao.Core;
using hudao.Views.Inventory;
using hudao.Views.Inventory.Index;

namespace hudao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ss = Application.Current.Windows;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Navigator.Current.ShowMessage(MessageLevel.INFO, "Hello World");
            Navigator.Current.GotoView(new IndexView());
           
            //this.ViewContainer.Content = new IndexView();
        }
    }
}

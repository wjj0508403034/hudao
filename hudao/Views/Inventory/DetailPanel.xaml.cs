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

namespace hudao.Views.Inventory
{
    /// <summary>
    /// Interaction logic for DetailPanel.xaml
    /// </summary>
    public partial class DetailPanel : UserControl
    {
        public DetailPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Current.GotoView(new ListPanel());
        }
    }
}

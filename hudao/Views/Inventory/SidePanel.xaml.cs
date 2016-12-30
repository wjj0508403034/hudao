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
    /// Interaction logic for SidePanel.xaml
    /// </summary>
    public partial class SidePanel
    {
        public SidePanel()
        {
            InitializeComponent();
            var xx = new TestXX();

            xx.Items.Add(new Test() { CreateTime = DateTime.Now, TestNo = "11111" });
            xx.Items.Add(new Test() { CreateTime = DateTime.Now, TestNo = "11112" });
            this.TestListBox.ItemsSource = xx.Items;
        }


    }
}

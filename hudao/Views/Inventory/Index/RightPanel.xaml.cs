using System;
using System.Windows;
using hudao.Core;

namespace hudao.Views.Inventory.Index
{
    /// <summary>
    /// Interaction logic for RightPanel.xaml
    /// </summary>
    public partial class RightPanel
    {
        public RightPanel()
        {
            InitializeComponent();

            var xx = new TestXX();


            xx.Items.Add(new Test() { CreateTime = DateTime.Now, TestNo = "11111" });
            xx.Items.Add(new Test() { CreateTime = DateTime.Now, TestNo = "11112" });
            this.TestDataGrid.ItemsSource = xx.Items;
        }

        private void OnDetailButtonClick(object sender, RoutedEventArgs e)
        {
            Navigator.Current.GotoView(new DetailView());
        }
    }
}

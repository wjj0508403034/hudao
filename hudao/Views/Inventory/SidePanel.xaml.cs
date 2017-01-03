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
using hudao.Views.Common.Dialogs;

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

        private void OnPlusButtonClicked(Button button, RoutedEventArgs e)
        {
            ConfirmDialog confirmDialog = new ConfirmDialog();
            confirmDialog.OKButtonText = "Continue";
            confirmDialog.CancelButtonClicked += confirmDialog_CancelButtonClicked;
            confirmDialog.OKButtonClicked += confirmDialog_OKButtonClicked;
            confirmDialog.OpenDialog();
        }

        private void confirmDialog_OKButtonClicked(Dialog dialog, Button button, RoutedEventArgs e)
        {
            dialog.Close();
            Navigator.Current.GotoView(new Create());
        }

        private void confirmDialog_CancelButtonClicked(Dialog dialog, Button button, RoutedEventArgs e)
        {
            dialog.Close();
        }

        private void OnMenuButtonClicked(Button button, RoutedEventArgs e)
        {
            Navigator.Current.ShowMenu();
        }
    }
}

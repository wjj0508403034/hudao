using System;
using System.Windows;
using System.Windows.Controls;
using hudao.Core;
using hudao.Views.Common.Dialogs;

namespace hudao.Views.Inventory.Index
{
    /// <summary>
    /// Interaction logic for LeftPanel.xaml
    /// </summary>
    public partial class LeftPanel
    {
        public LeftPanel()
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
            Navigator.Current.GotoView(new CreateView());
        }

        private void confirmDialog_CancelButtonClicked(Dialog dialog, Button button, RoutedEventArgs e)
        {
            dialog.Close();
        }

        private void OnMenuButtonClicked(Button button, RoutedEventArgs e)
        {
            Navigator.Current.ToggleMenu();
        }
    }
}

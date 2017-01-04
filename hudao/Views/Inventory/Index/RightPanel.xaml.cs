using System;
using System.Windows;
using System.Windows.Controls;
using hudao.Core;
using hudao.Views.Common.Dialogs;

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

        private void OnConfirmDeliveryButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new ConfirmDialog();
            dialog.DialogContent = new ConfirmDeliveryDialogContent();
            dialog.OKButtonClicked += DialogOKButtonClicked;
            dialog.CancelButtonClicked += DialogCancelButtonClicked;
            dialog.ShowDialog();
        }

        private void DialogCancelButtonClicked(Dialog dialog, Button button, RoutedEventArgs e)
        {
            dialog.CloseDialog();
        }

        private void DialogOKButtonClicked(Dialog dialog, Button button, RoutedEventArgs e)
        {

        }
    }
}

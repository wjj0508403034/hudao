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
using hudao.Core.EventHandlers;
using hudao.Views.Common.Dialogs;

namespace hudao.Views.Inventory
{
    /// <summary>
    /// Interaction logic for DetailView.xaml
    /// </summary>
    public partial class DetailView 
    {
        public DetailView()
        {
            InitializeComponent();
        }

        public override void OnActive()
        {
            base.OnActive();
            Navigator.Current.SetTitle("收货商品详情");
        }

        private void OnBackButtonClicked(Button button, RoutedEventArgs e)
        {
            Navigator.Current.ShowWarn("收货商品详情",this.OnOkButtonClickHandler);
            Navigator.Current.BackView();
        }

        private void OnOkButtonClickHandler(Dialog dialog, Button button, RoutedEventArgs e)
        {
            var infoDialog = (InfoDialog) dialog;
            infoDialog.OKButtonClicked -= this.OnOkButtonClickHandler;
            infoDialog.Close();
        }
    }
}

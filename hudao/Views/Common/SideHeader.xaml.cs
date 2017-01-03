using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using hudao.Core.EventHandlers;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for SideHeader.xaml
    /// </summary>
    public partial class SideHeader
    {
        public SideHeader()
        {
            InitializeComponent();
        }

        private ButtonClickEventHandler onPlusButtonClicked;

        [Category("Behavior")]
        public event ButtonClickEventHandler PlusButtonClicked
        {
            add
            {
                onPlusButtonClicked += value;
            }
            remove
            {
                onPlusButtonClicked -= value;
            }
        }

        private ButtonClickEventHandler onMenuButtonClicked;

        [Category("Behavior")]
        public event ButtonClickEventHandler MenuButtonClicked
        {
            add
            {
                onMenuButtonClicked += value;
            }
            remove
            {
                onMenuButtonClicked -= value;
            }
        }

        private void OnPlusButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onPlusButtonClicked != null)
            {
                this.onPlusButtonClicked((Button)sender, e);
            }
        }

        private void OnMenuButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onMenuButtonClicked != null)
            {
                this.onMenuButtonClicked((Button)sender, e);
            }
        }
    }
}

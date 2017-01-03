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

namespace hudao.Views.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for InfoDialog.xaml
    /// </summary>
    public partial class InfoDialog
    {
        public InfoDialog(InfoLevel level, string message)
        {
            InitializeComponent();
            this.Level = level;
            this.Message = message;
            this.MessageContent.Text = this.Message;
        }

        private InfoLevel level;
        public InfoLevel Level
        {
            get { return this.level; }
            set
            {
                this.level = value;
                this.OnLevelChanged();
            }
        }

        public string Message;

        private DialogButtonClickEventHandler onOKButtonClicked;

        [Category("Behavior")]
        public event DialogButtonClickEventHandler OKButtonClicked
        {
            add
            {
                onOKButtonClicked += value;
            }
            remove
            {
                onOKButtonClicked -= value;
            }
        }

        private void OnLevelChanged()
        {
            this.InfoIcon.Visibility = Visibility.Hidden;
            this.WarnIcon.Visibility = Visibility.Hidden;
            this.ErrorIcon.Visibility = Visibility.Hidden;

            if (this.Level == InfoLevel.INFO)
            {
                this.InfoIcon.Visibility = Visibility.Visible;
                return;
            }

            if (this.Level == InfoLevel.WARN)
            {
                this.WarnIcon.Visibility = Visibility.Visible;
                return;
            }

            if (this.Level == InfoLevel.ERROR)
            {
                this.ErrorIcon.Visibility = Visibility.Visible;
            }

        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.onOKButtonClicked != null)
            {
                this.onOKButtonClicked(this, (Button)sender, e);
            }
        }
    }
}

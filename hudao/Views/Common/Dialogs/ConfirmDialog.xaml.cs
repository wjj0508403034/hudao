using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using hudao.Core.EventHandlers;

namespace hudao.Views.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfirmDialog.xaml
    /// </summary>
    public partial class ConfirmDialog
    {

        public ConfirmDialog()
        {
            InitializeComponent();
        }

        private object dialogContent;
        public object DialogContent
        {
            get { return this.dialogContent; }
            set
            {
                this.dialogContent = value;
                this.OnDialogContentChanged();
            }
        }
        public string OKButtonText;
        public string CancelButtonText;

        private DialogButtonClickEventHandler onCancelButtonClicked;

        [Category("Behavior")]
        public event DialogButtonClickEventHandler CancelButtonClicked
        {
            add
            {
                onCancelButtonClicked += value;
            }
            remove
            {
                onCancelButtonClicked -= value;
            }
        }


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

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.onCancelButtonClicked != null)
            {
                this.onCancelButtonClicked(this, (Button)sender, e);
            }
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.onOKButtonClicked != null)
            {
                this.onOKButtonClicked(this, (Button)sender, e);
            }
        }

        public override void CloseDialog()
        {
            if (this.onCancelButtonClicked != null)
            {
                this.CancelButtonClicked -= this.onCancelButtonClicked;
            }

            if (this.onOKButtonClicked != null)
            {
                this.OKButtonClicked -= this.onOKButtonClicked;
            }
            base.CloseDialog();
        }

        protected override void ApplyButtonTexts()
        {
            base.ApplyButtonTexts();
            if (this.OKButtonText != null)
            {
                this.OkButton.Content = this.OKButtonText;
            }

            if (this.CancelButtonText != null)
            {
                this.CancelButton.Content = this.CancelButtonText;
            }
        }

        private void OnDialogContentChanged()
        {
            this.DialogContentPresenter.Content = this.DialogContent;
        }
    }
}

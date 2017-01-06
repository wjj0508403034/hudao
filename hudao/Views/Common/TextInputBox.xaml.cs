using System.Windows;
using System.Windows.Media;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for TextInputBox.xaml
    /// </summary>
    public partial class TextInputBox
    {
        public TextInputBox()
        {
            InitializeComponent();
        }


        public double BoxHeight
        {
            get { return this.TextBox.Height; }
            set { this.TextBox.Height = value; }
        }

        public VerticalAlignment BoxContentVerticalAlignment
        {
            get { return this.TextBox.VerticalContentAlignment; }
            set { this.TextBox.VerticalContentAlignment = value; }
        }

        private Brush errorBrush;
        public Brush ErrorBrush
        {
            get { return this.errorBrush ?? (this.errorBrush = (Brush) this.FindResource("ErrorBrush")); }
        }

        private Brush boxBrush;
        public Brush BoxBrush
        {
            get { return this.boxBrush ?? (this.boxBrush = (Brush)this.FindResource("BoxBrush")); }
        }


        private bool hasError;
        public bool HasError
        {
            get { return this.hasError; }
            set
            {
                if (value)
                {
                    this.TextBox.BorderBrush = this.ErrorBrush;
                    this.ErrorContentPresenter.Visibility = Visibility.Visible;
                }
                else
                {
                    this.TextBox.BorderBrush = this.BoxBrush;
                    this.ErrorContentPresenter.Visibility = Visibility.Collapsed;
                }
                this.hasError = value;
            }
        }

        public object ErrorContent
        {
            get { return this.ErrorContentPresenter.Content; }
            set { this.ErrorContentPresenter.Content = value; }
        }
    }
}

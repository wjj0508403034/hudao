using System.Windows;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for FieldLabel.xaml
    /// </summary>
    public partial class FieldLabel
    {
        public FieldLabel()
        {
            InitializeComponent();
        }

        public Visibility StarVisibility
        {
            get { return this.Star.Visibility; }
            set { this.Star.Visibility = value; }
        }

        public object LabelContent
        {
            get { return this.Label.Content; }
            set { this.Label.Content = value; }
        }
    }
}

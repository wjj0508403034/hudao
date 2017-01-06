using System.Windows;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for PropertyField.xaml
    /// </summary>
    public partial class PropertyField
    {
        public PropertyField()
        {
            InitializeComponent();
        }

        public GridLength KeyContentWidth
        {
            get { return this.KeyContentColumn.Width; }
            set { this.KeyContentColumn.Width = value; }
        }

        public GridLength ValueContentWidth
        {
            get { return this.ValueContentColumn.Width; }
            set { this.ValueContentColumn.Width = value; }
        }

        public VerticalAlignment KeyContentVerticalAlignment
        {
            get { return this.KeyContentPresenter.VerticalAlignment; }
            set { this.KeyContentPresenter.VerticalAlignment = value; }
        }

        public object KeyContent
        {
            get { return this.KeyContentPresenter.Content; }
            set { this.KeyContentPresenter.Content = value; }
        }


        public object ValueContent
        {
            get { return this.ValueContentPresenter.Content; }
            set { this.ValueContentPresenter.Content = value; }
        }

    }
}

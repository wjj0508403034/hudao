namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for CirclePanel.xaml
    /// </summary>
    public partial class CirclePanel
    {
        public CirclePanel()
        {
            InitializeComponent();
        }

        public object PanelContent
        {
            get { return this.ContentPresenter.Content; }
            set { this.ContentPresenter.Content = value; }
        }
    }
}

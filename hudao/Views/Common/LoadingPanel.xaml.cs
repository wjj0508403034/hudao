namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for LoadingPanel.xaml
    /// </summary>
    public partial class LoadingPanel
    {
        public LoadingPanel()
        {
            InitializeComponent();
        }

        public object LoadingContent
        {
            get { return this.LoadingContentPresenter.Content; }
            set { this.LoadingContentPresenter.Content = value; }
        }
    }
}

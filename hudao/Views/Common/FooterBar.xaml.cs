namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for FooterBar.xaml
    /// </summary>
    public partial class FooterBar
    {
        public FooterBar()
        {
            InitializeComponent();
        }

        public object FooterContent
        {
            get { return this.ContentPresenter.Content; }
            set { this.ContentPresenter.Content = value; }
        }
    }
}

using hudao.Core;
using hudao.Views.Inventory.Index;

namespace hudao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.Current.GotoView(new IndexView());
        }
    }
}

using hudao.Core;

namespace hudao.Views.Inventory
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView 
    {
        public CreateView()
        {
            InitializeComponent();
        }

        public override void OnActive()
        {
            base.OnActive();
            Navigator.Current.SetTitle("新建xxx");
        }
    }
}

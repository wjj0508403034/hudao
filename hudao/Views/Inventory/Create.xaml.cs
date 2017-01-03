using hudao.Core;

namespace hudao.Views.Inventory
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create 
    {
        public Create()
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

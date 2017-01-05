using System.Windows;
using System.Windows.Controls;
using hudao.Views.Common.KeyBoards;

namespace hudao.Views.MemberShip.Index
{
    /// <summary>
    /// Interaction logic for RightPanel.xaml
    /// </summary>
    public partial class RightPanel
    {
        public RightPanel()
        {
            InitializeComponent();
        }

        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
   
        }

        private void OnKeyButtonClicked(KeyBoard keyBoard, Button button, KeyCode keyCode)
        {
            this.SearchBox.SearchText += keyCode.StringValue();
        }
    }
}

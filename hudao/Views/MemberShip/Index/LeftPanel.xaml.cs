using System.Windows;
using hudao.Core;

namespace hudao.Views.MemberShip.Index
{
    /// <summary>
    /// Interaction logic for LeftPanel.xaml
    /// </summary>
    public partial class LeftPanel
    {
        public LeftPanel()
        {
            InitializeComponent();
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            Navigator.Current.BackView();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

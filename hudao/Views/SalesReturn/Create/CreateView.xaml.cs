using System.Windows;
using System.Windows.Controls;
using hudao.Core;

namespace hudao.Views.SalesReturn.Create
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

        private void TitlePanel_BackButtonClicked(Button button, RoutedEventArgs e)
        {
            Navigator.Current.ToggleMenu();
        }
    }
}

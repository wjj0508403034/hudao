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

        private void BackButtonClicked(Button button, RoutedEventArgs e)
        {
            Navigator.Current.ToggleMenu();
        }

        private void SaveAndBackButtonClick(object sender, RoutedEventArgs e)
        {
            Navigator.Current.BackView();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

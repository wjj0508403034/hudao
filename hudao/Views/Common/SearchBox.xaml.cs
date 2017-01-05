using System.Windows;
using System.Windows.Controls;
using hudao.Utils;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        public string SearchText
        {
            get { return this.SeachTextBox.Text; }
            set
            {
                this.SeachTextBox.Text = value;
            }
        }


        private void onSeachTextChanged(object sender, TextChangedEventArgs e)
        {
            if (StringUtils.IsEmpty(this.SearchText))
            {
                this.PlaceHolderBox.Visibility = Visibility.Visible;
                this.ClearButton.Visibility = Visibility.Hidden;
                this.SearchButton.Visibility = Visibility.Visible;
            }
            else
            {
                this.PlaceHolderBox.Visibility = Visibility.Hidden;
                this.ClearButton.Visibility = Visibility.Visible;
                this.SearchButton.Visibility = Visibility.Hidden;
            }
        }

        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            this.SearchText = string.Empty;
        }
    }
}

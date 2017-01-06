using System.Windows;

namespace hudao.Views.Common.KeyBoards
{
    /// <summary>
    /// Interaction logic for NumberKeyBoard.xaml
    /// </summary>
    public partial class NumberKeyBoard
    {
        public NumberKeyBoard()
        {
            InitializeComponent();
        }

        public Visibility PointButtonVisibility
        {
            get { return this.PointButton.Visibility; }
            set { this.PointButton.Visibility = value; }
        }
    }
}

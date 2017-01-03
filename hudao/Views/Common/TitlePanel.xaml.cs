using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using hudao.Core.EventHandlers;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for TitlePanel.xaml
    /// </summary>
    public partial class TitlePanel
    {
        public TitlePanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register(
                  "Title",
                  typeof(string),
                  typeof(TitlePanel), new FrameworkPropertyMetadata(
                          string.Empty,
                          new PropertyChangedCallback(OnTitleChanged)));

        public static readonly DependencyProperty HideBackProperty =
          DependencyProperty.Register(
                  "HideBack",
                  typeof(bool),
                  typeof(TitlePanel), new FrameworkPropertyMetadata(
                          false,
                          FrameworkPropertyMetadataOptions.AffectsMeasure,
                          new PropertyChangedCallback(OnHideBackChanged)));


        [Bindable(true)]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        [Bindable(true)]
        public bool HideBack
        {
            get { return (bool)GetValue(HideBackProperty); }
            set { SetValue(HideBackProperty, value); }
        }

        private ButtonClickEventHandler onBackButtonClicked;

        [Category("Behavior")]
        public event ButtonClickEventHandler BackButtonClicked
        {
            add
            {
                onBackButtonClicked += value;
            }
            remove
            {
                onBackButtonClicked -= value;
            }
        }


        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var titlePanel = (TitlePanel)d;
            titlePanel.TitleContent.Text = titlePanel.Title;
        }

        private static void OnHideBackChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var titlePanel = (TitlePanel)d;
            titlePanel.BackButton.Visibility = titlePanel.HideBack ? Visibility.Hidden : Visibility.Visible;
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            if(this.onBackButtonClicked != null)
            {
                this.onBackButtonClicked((Button) sender, e);
            }
        }
    }
}

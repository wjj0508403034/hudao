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

        public static readonly DependencyProperty BackButtonVisibilityProperty =
          DependencyProperty.Register(
                  "BackButtonVisibility",
                  typeof(Visibility),
                  typeof(TitlePanel), new FrameworkPropertyMetadata(
                          Visibility.Visible,
                          FrameworkPropertyMetadataOptions.AffectsMeasure,
                          new PropertyChangedCallback(OnHideBackChanged)));


        [Bindable(true)]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        [Bindable(true)]
        public Visibility BackButtonVisibility
        {
            get { return (Visibility)GetValue(BackButtonVisibilityProperty); }
            set { SetValue(BackButtonVisibilityProperty, value); }
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
            titlePanel.BackButton.Visibility = titlePanel.BackButtonVisibility;
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

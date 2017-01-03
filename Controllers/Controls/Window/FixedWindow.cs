using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Controllers.Controls.Window
{
    [TemplatePart(Name = HeaderContainerName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = MinimizeButtonName, Type = typeof(Button))]
    [TemplatePart(Name = CloseButtonName, Type = typeof(Button))]
    public class FixedWindow : System.Windows.Window
    {
        static FixedWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FixedWindow), new FrameworkPropertyMetadata(typeof(FixedWindow)));
        }

        public static readonly DependencyProperty ShowTitleProperty =
            DependencyProperty.Register("ShowTitle", typeof(bool), typeof(FixedWindow), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty HeaderVisibilityProperty =
            DependencyProperty.Register("HeaderVisibility", typeof(Visibility), typeof(FixedWindow), new FrameworkPropertyMetadata(Visibility.Visible,
                          FrameworkPropertyMetadataOptions.AffectsMeasure,
                          new PropertyChangedCallback(OnShowHeaderChanged)));



        public bool ShowTitle
        {
            get { return (bool)GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        public Visibility HeaderVisibility
        {
            get { return (Visibility)GetValue(HeaderVisibilityProperty); }
            set { SetValue(HeaderVisibilityProperty, value); }
        }

        #region Template Part Name
        private const string HeaderContainerName = "PART_HeaderContainer";

        private const string MinimizeButtonName = "PART_MinimizeButton";

        private const string CloseButtonName = "PART_CloseButton";
        #endregion

        #region Private Fields
        private FrameworkElement headerContainer;
        private Button minimizeButton;
        private Button closeButton;
        #endregion


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            headerContainer = GetTemplateChild<FrameworkElement>(HeaderContainerName);
            headerContainer.MouseLeftButtonDown += HeaderContainerMouseLeftButtonDown;

            // close window
            closeButton = GetTemplateChild<Button>(CloseButtonName);
            closeButton.Click += delegate { Close(); };

            // minimized
            minimizeButton = GetTemplateChild<Button>(MinimizeButtonName);
            minimizeButton.Click += new RoutedEventHandler(minimizeButton_Click);
        }

        void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private T GetTemplateChild<T>(string childName) where T : FrameworkElement, new()
        {
            return (GetTemplateChild(childName) as T) ?? new T();
        }

        private void HeaderContainerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private static void OnShowHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
//            var window = (FixedWindow)d;
//            if (window.headerContainer != null)
//            {
//                window.headerContainer.Visibility = window.ShowHeader ? Visibility.Visible : Visibility.Collapsed;
//            }
        }
    }
}

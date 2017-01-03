using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MS.Internal.PresentationFramework;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for PropertyField.xaml
    /// </summary>
    public partial class PropertyField
    {
        public PropertyField()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty KeyContentProperty =
             DependencyProperty.Register(
                  "KeyContent",
                  typeof(object),
                  typeof(PropertyField), new FrameworkPropertyMetadata(
                           (object)null,
                            FrameworkPropertyMetadataOptions.AffectsMeasure,
                          new PropertyChangedCallback(OnKeyContentChanged)));

        public object KeyContent
        {
            get { return GetValue(KeyContentProperty); }
            set { SetValue(KeyContentProperty, value); }
        }

        public static readonly DependencyProperty ValueContentProperty =
            DependencyProperty.Register(
                 "ValueContent",
                 typeof(object),
                 typeof(PropertyField), new FrameworkPropertyMetadata(
                          (object)null,
                           FrameworkPropertyMetadataOptions.AffectsMeasure,
                         new PropertyChangedCallback(OnValueContentChanged)));


        public object ValueContent
        {
            get { return GetValue(ValueContentProperty); }
            set { SetValue(ValueContentProperty, value); }
        }

        private static void OnKeyContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var field = (PropertyField)d;
            field.KeyContentPresenter.Content = field.KeyContent;
        }
        private static void OnValueContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var field = (PropertyField)d;
            field.ValueContentPresenter.Content = field.ValueContent;
        }
    }
}

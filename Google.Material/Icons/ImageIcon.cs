using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Google.Material.Icons
{
    public class ImageIcon : Image
    {
        private static readonly FontFamily ImageIconFontFamily = new FontFamily(new Uri("pack://application:,,,/Google.Material;component/Icons/fonts/"), "./#Material Icons");

        private static readonly Typeface ImageIconTypeface = new Typeface(ImageIconFontFamily, FontStyles.Normal, FontWeights.Light, FontStretches.Normal);

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(ImageIcon), new PropertyMetadata(Brushes.Black, OnIconPropertyChanged));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Icon), typeof(ImageIcon), new PropertyMetadata(Icon.None, OnIconPropertyChanged));

        static ImageIcon()
        {
            OpacityProperty.OverrideMetadata(typeof(ImageIcon), new UIPropertyMetadata(1.0, OpacityChanged));
        }

        private static void OpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }


        public Brush Foreground
        {
            get
            {
                return (Brush)this.GetValue(ForegroundProperty);
            }
            set
            {
                this.SetValue(ForegroundProperty, value);
            }
        }

        public Icon Icon
        {
            get
            {
                return (Icon)this.GetValue(IconProperty);
            }
            set
            {
                this.SetValue(IconProperty, value);
            }
        }


        private static void OnIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var imageIcon = d as ImageIcon;
            if (imageIcon == null)
                return;
            d.SetValue(SourceProperty, CreateImageSource(imageIcon.Icon, imageIcon.Foreground));
        }

        private static ImageSource CreateImageSource(Icon icon, Brush foregroundBrush)
        {
            var textToFormat = icon.GetIdValue();
            if(string.IsNullOrEmpty(textToFormat))
            {
                return null;
            }

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawText(new FormattedText(textToFormat, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, ImageIconTypeface, 10000.0, foregroundBrush)
                {
                    TextAlignment = TextAlignment.Center
                }, new Point(0.0, 0.0));
            return new DrawingImage(drawingVisual.Drawing);
        }

    }
}

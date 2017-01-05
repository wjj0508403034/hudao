using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Controllers.Controls.Text
{
    public static class TextExtension
    {
        public static readonly DependencyProperty PatternProperty
            = DependencyProperty.RegisterAttached("Pattern", typeof(string), typeof(TextExtension),
                                                  new PropertyMetadata(string.Empty, OnPatternChanged));

        public static string GetPattern(DependencyObject obj)
        {
            return (string)obj.GetValue(PatternProperty);
        }

        public static void SetPattern(DependencyObject obj, string pattern)
        {
            obj.SetValue(PatternProperty, pattern);
        }

        private static void OnPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox)d;
            if (textBox != null)
            {
                textBox.PreviewTextInput -= PreviewTextInput;
                textBox.TextChanged -= TextChanged;
                var pattern = (string)e.NewValue;
                if (!string.IsNullOrEmpty(pattern))
                {
                    textBox.PreviewTextInput += PreviewTextInput;
                    textBox.TextChanged += TextChanged;
                }

            }
        }

        static void TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var changes = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(changes, 0);
            var offset = changes[0].Offset;
            var length = changes[0].AddedLength;
            if (length > 0)
            {
                var input = textBox.Text.Substring(offset, length);
                if (input != string.Empty)
                {
                    var pattern = GetPattern(textBox);
                    var regex = new Regex(pattern);
                    if (!regex.Match(input).Success)
                    {
                        textBox.Text = textBox.Text.Remove(offset, length);
                    }
                    textBox.Select(textBox.Text.Length, 0);   
                }
            }
        }

        private static void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var pattern = GetPattern((DependencyObject)sender);
            var regex = new Regex(pattern);
            if (!regex.Match(e.Text).Success)
            {
                e.Handled = true;
            }
        }
    }
}

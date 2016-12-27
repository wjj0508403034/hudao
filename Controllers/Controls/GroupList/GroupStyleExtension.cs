using System;
using System.Windows;
using System.Windows.Controls;

namespace Controllers.Controls.GroupList
{
    public static class GroupStyleExtension
    {
        public static readonly DependencyProperty AppendProperty
            = DependencyProperty.RegisterAttached("Append", typeof(GroupStyle), typeof(GroupStyleExtension),
                                                  new PropertyMetadata(AppendChanged));

        public static GroupStyle GetAppend(DependencyObject obj)
        {
            return (GroupStyle)obj.GetValue(AppendProperty);
        }

        public static void SetAppend(DependencyObject obj, GroupStyle style)
        {
            obj.SetValue(AppendProperty, style);
        }

        private static void AppendChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var itemsControl = d as ItemsControl;
            if (itemsControl == null)
                throw new InvalidOperationException("Can only add GroupStyle to ItemsControl");

            var newGroupStyle = e.NewValue as GroupStyle;
            if (newGroupStyle != null)
                itemsControl.GroupStyle.Add(newGroupStyle);
        }
    }
}

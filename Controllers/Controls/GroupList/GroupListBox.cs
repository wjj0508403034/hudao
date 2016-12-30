using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Controllers.Controls.GroupList
{
    [Localizability(LocalizationCategory.ListBox)]
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(ListBoxItem))]
    public class GroupListBox : ListBox
    {

        static GroupListBox()
        {
           // DefaultStyleKeyProperty.OverrideMetadata(typeof(GroupListBox), new FrameworkPropertyMetadata(typeof(GroupListBox)));
        }
        public static readonly DependencyProperty GroupMemberPathProperty =
          DependencyProperty.Register(
                  "GroupMemberPath",
                  typeof(string),
                  typeof(GroupListBox),
                  new FrameworkPropertyMetadata(
                          string.Empty,
                          new PropertyChangedCallback(OnGroupMemberPathChanged)));

        [Bindable(true)]
        public string GroupMemberPath
        {
            get { return (string)GetValue(GroupMemberPathProperty); }
            set { SetValue(GroupMemberPathProperty, value); }
        }

        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            this.ApplyGroupItemSource();
        }

        private static void OnGroupMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var groupListBox = (GroupListBox)d;
            groupListBox.ApplyGroupItemSource();
        }

        private void ApplyGroupItemSource()
        {
            var view = (CollectionView)CollectionViewSource.GetDefaultView(this.ItemsSource);
            if (view != null)
            {
                var groupDescription = new PropertyGroupDescription(this.GroupMemberPath);
                if (view.GroupDescriptions != null)
                {
                    view.GroupDescriptions.Add(groupDescription);
                }
            }
        }
    }
}

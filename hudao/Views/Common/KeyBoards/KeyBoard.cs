using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using hudao.Core.EventHandlers;

namespace hudao.Views.Common.KeyBoards
{
    public class KeyBoard : UserControl
    {
        private KeyBoardButtonClickEventHandler onKeyButtonClicked;

        [Category("Behavior")]
        public event KeyBoardButtonClickEventHandler KeyButtonClicked
        {
            add
            {
                onKeyButtonClicked += value;
            }
            remove
            {
                onKeyButtonClicked -= value;
            }
        }

        protected void OnKeyButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.onKeyButtonClicked != null)
            {
                var button = (Button)sender;
                this.onKeyButtonClicked(this, button, (KeyCode)button.Tag);
            }
        }
    }
}

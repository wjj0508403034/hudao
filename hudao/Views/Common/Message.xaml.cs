using hudao.Core;

namespace hudao.Views.Common
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message 
    {
        public Message(MessageLevel level, string text)
        {
            InitializeComponent();
            this.Text = text;
            this.Level = level;
        }
    }
}

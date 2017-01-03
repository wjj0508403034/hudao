using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using hudao.Core.EventHandlers;

namespace hudao.Core
{
    public class BaseMessage : UserControl, IMessage
    {
        private const double Interval = 5000d;
        public string Text;
        public MessageLevel Level;

        private MessageCloseEventHandler onMessageClosed;
        private readonly Timer timer = new Timer(Interval);

        [Category("Behavior")]
        public event MessageCloseEventHandler MessageClosed
        {
            add
            {
                onMessageClosed += value;
            }
            remove
            {
                onMessageClosed -= value;
            }
        }

        public void Show()
        {
            this.timer.Start();
            this.timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.timer.Stop();
            this.timer.Elapsed -= TimerElapsed;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => this.onMessageClosed(this)));
        }
    }
}

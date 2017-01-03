using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hudao.Core.EventHandlers;
using hudao.Views.Common;
using hudao.Views.Common.Dialogs;
using log4net;

namespace hudao.Core
{
    public class Navigator
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Navigator));
        public static readonly Navigator Current = new Navigator();

        private ContentControl _viewContainer;
        public ContentControl ViewContainer
        {
            get
            {
                if (this._viewContainer == null)
                {
                    this._viewContainer = this.GetControlFromMainWindow<ContentControl>("ViewContainer");
                }
                return _viewContainer;
            }
        }

        private StackPanel _messageContainer;
        public StackPanel MessageContainer
        {
            get
            {
                if (this._messageContainer == null)
                {
                    this._messageContainer = this.GetControlFromMainWindow<StackPanel>("MessageContainer");
                }

                return this._messageContainer;
            }
        }

        private readonly Stack<IView> _histories = new Stack<IView>();

        public void GotoView(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            Logger.Info("Go to view " + view.GetViewName() + " ...");
            if (this.ViewContainer.Content is IView)
            {
                var oldView = (IView)this.ViewContainer.Content;
                oldView.OnDeactive();
                Logger.Info("Push old view " + oldView.GetViewName() + " in the history.");
                this._histories.Push(oldView);
            }
            this.ViewContainer.Content = view;
            view.OnActive();
            Logger.Info("Go to view " + view.GetViewName() + " end.");
        }

        public void BackView()
        {
            if (this._histories.Count == 0)
            {
                Logger.Warn("Cannot back, because current view is the last view");
                return;
            }

            var view = this._histories.Pop();
            Logger.Info("Back to view " + view.GetViewName() + " .");
            this.ViewContainer.Content = view;
        }

        public void ShowMenu()
        {

        }

        public void HideMenu()
        {

        }

        public void ShowDialog(IDialog dialog)
        {

        }

        public void ShowInfo(string message, DialogButtonClickEventHandler clickHandler = null)
        {
            var dialog = new InfoDialog(InfoLevel.INFO, message);
            if (clickHandler != null)
            {
                dialog.OKButtonClicked += clickHandler;
            }
            dialog.OpenDialog();
        }

        public void ShowWarn(string message, DialogButtonClickEventHandler clickHandler = null)
        {
            var dialog = new InfoDialog(InfoLevel.WARN, message);
            if (clickHandler != null)
            {
                dialog.OKButtonClicked += clickHandler;
            }
            dialog.OpenDialog();
        }

        public void ShowError(string message, DialogButtonClickEventHandler clickHandler = null)
        {
            var dialog = new InfoDialog(InfoLevel.ERROR, message);
            if (clickHandler != null)
            {
                dialog.OKButtonClicked += clickHandler;
            }
            dialog.OpenDialog();
        }

        public void SetTitle(String title)
        {
            Application.Current.MainWindow.Title = title;
        }

        public void ShowMessage(MessageLevel level, string text)
        {
            var message = new Message(level, text);
            message.MessageClosed += onMessageClosed;
            this.MessageContainer.Children.Add(message);
            message.Show();
        }

        private void onMessageClosed(BaseMessage message)
        {
            message.MessageClosed -= onMessageClosed;
            this.MessageContainer.Children.Remove(message);
        }

        private T GetControlFromMainWindow<T>(string name)
        {
            return (T)Application.Current.MainWindow.FindName(name);
        }
    }
}

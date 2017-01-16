using System;
using System.Collections.Generic;
using System.Windows;
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

        private static MainWindow MainWindow
        {
            get { return (MainWindow)Application.Current.MainWindow; }
        }

        private readonly Stack<IView> _histories = new Stack<IView>();

        public void SetView(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }
            this._histories.Clear();
            MainWindow.ViewContent = view;
            view.OnActive();
        }

        public void GotoView(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            Logger.Info("Go to view " + view.GetViewName() + " ...");
            if (MainWindow.ViewContent is IView)
            {
                var oldView = (IView)MainWindow.ViewContent;
                oldView.OnDeactive();
                Logger.Info("Push old view " + oldView.GetViewName() + " in the history.");
                this._histories.Push(oldView);
            }
            MainWindow.ViewContent = view;
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
            MainWindow.ViewContent = view;
        }

        public void ShowMenu()
        {
            MainWindow.ShowMenu();
        }

        public void HideMenu()
        {
            MainWindow.HideMenu();
        }

        public void ToggleMenu()
        {
            if (this.IsMenuOpen())
            {
                this.HideMenu();
            }
            else
            {
                this.ShowMenu();
            }
        }

        public bool IsMenuOpen()
        {
            return MainWindow.IsMenuOpen;
        }

        public void ShowLoading(string loadingText = null)
        {
            MainWindow.LoadingVisibility = Visibility.Visible;
        }

        public void HideLoading()
        {
            MainWindow.LoadingVisibility = Visibility.Hidden;
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
            MainWindow.AddMessage(message);
            message.Show();
        }

        private void onMessageClosed(BaseMessage message)
        {
            message.MessageClosed -= onMessageClosed;
            MainWindow.RemoveMessage(message);
        }
    }
}

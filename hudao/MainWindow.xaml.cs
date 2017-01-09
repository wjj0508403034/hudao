﻿using System;
using System.Configuration;
using System.Windows;
using hudao.Core;
using hudao.Views.Common.Menu;
using hudao.Views.SalesReturn.Create;
using log4net;

namespace hudao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            //var ss = ConfigurationManager.GetSection("hudao");
            Navigator.Current.GotoView(new CreateView());
        }

        public Visibility MenuVisibility
        {
            get { return this.MenuBar.Visibility; }
            set { this.MenuBar.Visibility = value; }
        }

        public Visibility LoadingVisibility
        {
            get { return this.LoadingPanel.Visibility; }
            set { this.LoadingPanel.Visibility = value; }
        }

        public object ViewContent
        {
            get { return this.ViewContainer.Content; }
            set { this.ViewContainer.Content = value; }
        }

        public void AddMessage(UIElement element)
        {
            this.MessageContainer.Children.Add(element);
        }

        public void RemoveMessage(UIElement element)
        {
            this.MessageContainer.Children.Remove(element);
        }

        private void OnMenuItemChanged(MenuBar menuBar, MenuChangeEventArgs e)
        {
            var menuItem = menuBar.SelectedMenuItem;
            var viewType = (Type)menuItem.Tag;
            if (viewType != null)
            {
                try
                {
                    Navigator.Current.SetView((IView)Activator.CreateInstance(viewType));
                }
                catch (Exception ex)
                {
                    Logger.Error("New view failed", ex);
                }
            }
        }
    }
}

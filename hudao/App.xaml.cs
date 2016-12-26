using System.Windows;
using System.Windows.Threading;
using hudao.Core;
using hudao.Properties;
using log4net;

namespace hudao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.Info("Application start up ...");
        }


        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Logger.Info("Application Exit.");
            Settings.Default.Save();
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Logger.Error("Application occur exception", e.Exception);
        }
    }
}

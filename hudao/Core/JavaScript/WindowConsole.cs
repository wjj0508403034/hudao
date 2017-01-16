using log4net;

namespace hudao.Core.JavaScript
{
    public class WindowConsole
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WindowConsole));

        public void log(object obj)
        {
            Logger.Info(obj);
        }
    }
}

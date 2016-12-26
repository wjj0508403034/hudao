using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using log4net;

namespace hudao.Core
{
    public class BaseView : UserControl, IView
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BaseView));

        public string GetViewName()
        {
            return this.GetType().Name;
        }

        public void OnActive()
        {
            Logger.Info(this.GetViewName() + " is active.");
        }

        public void OnDeactive()
        {
            Logger.Info(this.GetViewName() + " is deactive.");
        }
    }
}

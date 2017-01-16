using System.IO;
using System.Text;
using log4net;

namespace hudao.Core.JavaScript
{
    public class JsShell
    {
       /* private static readonly ILog Logger = LogManager.GetLogger(typeof(JsShell));
        private readonly JavascriptContext context = new JavascriptContext();

        public JsShell()
        {
           this.context.SetParameter("console",new WindowConsole());
        }

        public void Import(string filePath)
        {
            var content = File.ReadAllText(@"Resources\JavaScripts\HuDaoCore.js", Encoding.UTF8);
            this.context.Run(content);
        }

        public void Run()
        {
            var content = File.ReadAllText(@"Resources\JavaScripts\HuDaoCore.js", Encoding.UTF8);
            var ss = this.context.Run(content,"AA");
           var yy= context.GetParameter("ss");
           var oo= this.context.Run("sayHi(1)");
        }*/

//        public object CallFunc(string funcName,params object[] _params)
//        {
//            string script = null;
//            if(_params.Length == 0)
//            {
//                script = funcName + "()";
//            }
//            else
//            {
//                
//            }
//            //return this.context.Run()
//
//        }
    }
}

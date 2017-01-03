using Controllers.Controls.Window;

namespace hudao.Views.Common.Dialogs
{
    public class Dialog : FixedWindow
    {
        public virtual bool? OpenDialog()
        {
            this.ApplyButtonTexts();
            return this.ShowDialog();
        }

        protected virtual void ApplyButtonTexts()
        {
            
        }
    }
}

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

        public virtual void CloseDialog()
        {
            this.Close();
        }

        protected virtual void ApplyButtonTexts()
        {
            
        }
    }
}

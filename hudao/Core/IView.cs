using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hudao.Core
{
    public interface IView
    {
        string GetViewName();

        void OnActive();

        void OnDeactive();
    }
}

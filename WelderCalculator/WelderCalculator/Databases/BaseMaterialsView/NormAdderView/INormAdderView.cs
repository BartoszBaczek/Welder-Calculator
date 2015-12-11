using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Databases.BaseMaterialsView
{
    public interface INormAdderView
    {
        NormAdderPresenter Presenter { set; }

        string NormName { get; set; }

        void CloseDialog();
    }
}

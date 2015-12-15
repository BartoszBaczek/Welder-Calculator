using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.MaterialDatabasePropertiesView;

namespace WelderCalculator.Databases.BaseMaterialsView
{
    public interface INormAdderView
    {
        NormAdderPresenter Presenter { set; }

        MaterialType MaterialType { get; }

        string NormName { get; set; }

        void CloseDialog();
    }
}

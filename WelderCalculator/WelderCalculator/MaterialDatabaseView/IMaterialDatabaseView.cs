using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabaseView
{
    public interface IMaterialDatabaseView
    {
        MaterialDatabasePresenter Presenter { set; }

        List<string> NormsList { set; }

        int SelectedNorm { get; set; }

        bool CcheckBox { get; set; }
        bool SiCheckBox { get; set; }
        bool MnCheckBox { get; set; }
        bool PcheckBox { get; set; }
        bool ScheckBox { get; set; }
        bool NcheckBox { get; set; }
        bool CrCheckBox { get; set; }
        bool MoCheckBox { get; set; }
        bool NbCheckBox { get; set; }
        bool NiCheckBox { get; set; }
        bool TiCheckBox { get; set; }
        bool AlCheckBox { get; set; }

        List<Material> GridSource { set; } 
    }
}
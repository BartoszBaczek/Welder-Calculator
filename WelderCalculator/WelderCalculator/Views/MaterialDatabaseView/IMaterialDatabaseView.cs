﻿using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Views.MaterialDatabaseView.MaterialDatabasePresenters;

namespace WelderCalculator.Views.MaterialDatabaseView
{
    public enum BaseMaterialDatabaseAccesibility
    {
        Full,
        PartialForFirstMaterial,
        PartialForSecondMaterial
    }

    public interface IMaterialDatabaseView
    {
        MaterialDatabasePresenter Presenter { set; }
        BaseMaterialDatabaseAccesibility Accesibility { get; }

        List<string> NormsList { get; set; }
        int SelectedNorm { get; set; }

        List<string> EquivalentsList { get; set; }
        int SelectedEquivalent { get; set; }

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
        bool VCheckBox { get; set;  }
        bool CuCheckBox { get; set; }

        bool NumberCheckBox { get; set; }
        bool MinCheckBox { get; set; }
        bool MaxCheckBox { get; set; }
        bool RealCheckBox { get; set; }

        DataTable GridSource { set; }

        DataGridView DataGridView { get; }
        DataGridViewRow SelectedRow { get; }

        double? NiEquivalentTextBox { get; set; }
        double? CrEquivalentTextBox { get; set; }

        bool ChooseMaterialVisibityButton { get; set; }
        bool ModifyMaterialVisibilityLayoutPanel { get; set; }
        bool AddNormVisibilityButton { get; set; }
        bool DeleteNormVisibilityButton { get; set; }
    }
}
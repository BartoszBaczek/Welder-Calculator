using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Views.DeLongChartView
{
        public interface IDeLongChartView
        {
            DeLongChartPresenter Presenter { set; }

            int DrawPanelWidth { get; }
            int DrawPanelHeight { get; }
            IntPtr DrawPanelCanvas { get; }

            bool FerriteNumberVisibleCheckBox { get; set; }
            bool FerriteContentVisibleCheckBox { get; set; }
            bool PhaseVisibleCheckBox { get; set; }
            bool HashVisibleCheckBox { get; set; }
            bool XAxisVisibleCheckBox { get; set; }
            bool YAxisVisibleCheckBox { get; set; }
            bool PhaseLinesVisibleCheckBox { get; set; }
            bool RecomendedFerriteContentVisibleCheckBox { get; set; }

            string FirstBaseMaterialTextBox { get; set; }
            string SecondBaseMaterialTextBox { get; set; }
            string AdditionalMaterialTextBox { get; set; }
            double? AdditionalMaterialQuantity { get; set; }

            string NewMaterialMicrophaseTextBox { get; set; }
            string NewMaterialFerriteQuantityTextBox { get; set; }
    }
}

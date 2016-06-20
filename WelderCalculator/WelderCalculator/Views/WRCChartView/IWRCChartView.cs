using System;

namespace WelderCalculator.Views.WRCChartView
{
    public interface IWRCChartView
    {
        WRCChartPresenter Presenter { set; }

        int DrawPanelWidth { get; }
        int DrawPanelHeight { get; }
        IntPtr DrawPanelCanvas { get; }

        bool HashVisibleCheckBox { get; set; }
        bool AxisVisibleCheckBox { get; set; }
        bool FerriteNumberVisibleCheckBox { get; set; }
        bool PhaseVisibleCheckBox { get; set; }

        string FirstBaseMaterialTextBox { get; set; }
        string SecondBaseMaterialTextBox { get; set; }
        string AdditionalMaterialTextBox { get; set; }
        double? AdditionalMaterialQuantity { get; set; }

        string NewMaterialMicrophaseTextBox { get; set; }
        string NewMaterialFerriteNumberTextBox { get; set; }
    }
}

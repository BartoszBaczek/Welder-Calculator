using System;

namespace WelderCalculator.Views.SchaefflerChartView
{
    public interface ISchaefflerChartView
    {
        SchaefflerChartPresenter Presenter { set; }

        int DrawPanelWidth { get; }
        int DrawPanelHeight { get; }
        IntPtr DrawPanelCanvas { get; }

        bool BackgroundVisibleCheckBox { get; set; }
        bool HashVisibleCheckBox { get; set; }
        bool XAxisVisibleCheckBox { get; set; }
        bool YAxisVisibleCheckBox { get; set; }
        bool PhaseLinesVisibleCheckBox { get; set; }

        string FirstBaseMaterialTextBox { get; set; }
        string SecondBaseMaterialTextBox { get; set; }
        string AdditionalMaterialTextBox { get; set; }
        double? AdditionalMaterialQuantity { get; set; }
    }
}

using System;

namespace WelderCalculator.Drawings.SchaefflerChartView
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
    }
}

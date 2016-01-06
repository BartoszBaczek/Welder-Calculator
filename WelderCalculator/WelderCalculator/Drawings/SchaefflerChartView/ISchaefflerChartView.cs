using System;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public interface ISchaefflerChartView
    {
        SchaefflerChartPresenter Presenter { set; }

        int DrawPanelWidth { get; }
        int DrawPanelHeight { get; }

        IntPtr DrawPanelCanvas { get; }
    }
}

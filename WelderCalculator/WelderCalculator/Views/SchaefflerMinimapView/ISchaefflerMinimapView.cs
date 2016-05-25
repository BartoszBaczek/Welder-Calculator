using System;

namespace WelderCalculator.Views.SchaefflerMinimapView
{
    public enum MinimapCombination
    {
        SchaefflerDeLong,
        SchaefflerWRC1992
    }

    public interface ISchaefflerMinimapView
    {
        SchaefflerMinimapPresenter Presenter { set; }

        int DrawPanelWidth { get; }
        int DrawPanelHeight { get; }
        IntPtr DrawPanelCanvas { get; }

        void CancelDialog();
    }
}

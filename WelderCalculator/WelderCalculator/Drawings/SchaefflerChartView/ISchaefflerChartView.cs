
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public interface ISchaefflerChartView
    {
        SchaefflerChartPresenter Presenter { set; }

        int CanvasWidth { get; }
        int CanvasHeight { get; }
    }
}

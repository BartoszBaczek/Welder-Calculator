using System.Collections.Generic;
using WelderCalculator.Drawings.SchaefflerChartView;

namespace WelderCalculator.Repositories
{
    public interface IDrawingsRepository
    {
        List<Layer> GetSchaefflerChartImages();
    }
}

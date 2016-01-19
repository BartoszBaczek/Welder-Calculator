using System.Collections.Generic;
using WelderCalculator.Drawings.Chart;

namespace WelderCalculator.Repositories
{
    public interface IDrawingsRepository
    {
        List<Layer> GetSchaefflerChartImages();
    }
}

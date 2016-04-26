using System.Collections.Generic;
using System.Drawing;
using WelderCalculator.Drawings.Chart;

namespace WelderCalculator.Repositories
{
    public interface IDrawingsRepository
    {
        List<Layer> GetSchaefflerChartImages();
        Image GetKsLogoImage();
    }
}

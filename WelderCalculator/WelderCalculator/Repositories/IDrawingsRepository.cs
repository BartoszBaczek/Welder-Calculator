using System.Collections.Generic;
using System.Drawing;

namespace WelderCalculator.Repositories
{
    public interface IDrawingsRepository
    {
        List<Image> GetSchaefflerChartImages();
    }
}

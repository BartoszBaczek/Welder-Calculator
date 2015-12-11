using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;


        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view;
            view.Presenter = this;
        }

        public void Draw(PaintEventArgs e)
        {
            string _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            string baseImagePath = _binPath + @"\.." + @"\Data\Images\images.png";
            string addImagePath = _binPath + @"\.." + @"\Data\Images\TestPrzez.png";

            Image newImage = Image.FromFile(baseImagePath);
            e.Graphics.DrawImage(newImage, new Point(0, 0));

            Image newImage2 = Image.FromFile(addImagePath);
            e.Graphics.DrawImage(newImage2, new Point(0, 0));
        }
    }
}

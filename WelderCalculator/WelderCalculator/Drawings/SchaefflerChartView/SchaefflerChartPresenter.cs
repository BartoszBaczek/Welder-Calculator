using System.Drawing;
using System.Drawing.Drawing2D;
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

            string schaefflerBackfround = _binPath + @"\.." + @"\Data\I\s_background.png";
            string schaefflerXAxis = _binPath + @"\.." + @"\Data\I\s_x.png";
            string schaefflerYAxis = _binPath + @"\.." + @"\Data\I\s_y.png";
            string schaefflerHash = _binPath + @"\.." + @"\Data\I\s_hash.png";
            string schaefflerPhaseMarkers = _binPath + @"\.." + @"\Data\I\s_phase.png";

            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Image newImage = Image.FromFile(schaefflerBackfround);
            e.Graphics.DrawImage(newImage, new Point(0, 0));

            newImage = Image.FromFile(schaefflerHash);
            e.Graphics.DrawImage(newImage, new Point(0, 0));

            newImage = Image.FromFile(schaefflerXAxis);
            e.Graphics.DrawImage(newImage, new Point(0, 0));

            newImage = Image.FromFile(schaefflerYAxis);
            e.Graphics.DrawImage(newImage, new Point(0, 0));

            newImage = Image.FromFile(schaefflerPhaseMarkers);
            e.Graphics.DrawImage(newImage, new Point(0, 0));
            
        }
    }
}

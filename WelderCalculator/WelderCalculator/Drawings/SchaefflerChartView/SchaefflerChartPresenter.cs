using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;
        private List<Image> imagesToDraw;
 
        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view;
            view.Presenter = this;
            LoadImages();
        }

        private void LoadImages()
        {
            string _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            List<string> pathsToDrawables = new List<string>()
            {
                _binPath + @"\.." + @"\Data\I\s_background.png",
                _binPath + @"\.." + @"\Data\I\s_x.png",
                _binPath + @"\.." + @"\Data\I\s_y.png",
                _binPath + @"\.." + @"\Data\I\s_hash.png",
                _binPath + @"\.." + @"\Data\I\s_phase.png"
            };

            imagesToDraw = new List<Image>();

            foreach (var path in pathsToDrawables)
                imagesToDraw.Add(Image.FromFile(path));
        }

        public void Draw(IntPtr panelHandle, PaintEventArgs e)
        {
            foreach (var image in imagesToDraw)
            {
                Bitmap resizedImage = ResizeImage(image, _view.CanvasWidth, _view.CanvasHeight);

                using (Graphics graphics = Graphics.FromHwnd(panelHandle))
                {
                    graphics.DrawImage(resizedImage,
                    new Rectangle(new Point(0, 0), new Size(_view.CanvasWidth, _view.CanvasHeight)));
                }
            }
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WelderCalculator.MaterialModificationView.Serialization;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;
        private List<Image> imagesToDraw;
        private readonly DataConnector _dataConnector;
 
        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view;
            view.Presenter = this; 
            _dataConnector = new DataConnector();

            LoadImages();
        }

        private void LoadImages()
        {
            imagesToDraw = _dataConnector.GetSchaefflerImages();
        }
         
        public void Draw(IntPtr panelHandle, PaintEventArgs e)
        {
            foreach (var image in imagesToDraw)
            {
                Bitmap resizedImage = ResizeImage(image, _view.DrawPanelWidth, _view.DrawPanelHeight);

                using (Graphics graphics = Graphics.FromHwnd(panelHandle))
                {
                    graphics.DrawImage(resizedImage,
                    new Rectangle(new Point(0, 0), new Size(_view.DrawPanelWidth, _view.DrawPanelHeight)));
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

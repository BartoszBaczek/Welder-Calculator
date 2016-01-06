using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class Chart
    {
        private List<Image> _originalLayers;
        private List<Image> _currentLayers;
        private Size _size;

        public List<Image> Layers
        {
            get { return _currentLayers; }
        }

        public Chart(List<Image> layers)
        {
            SetLayers(layers);
        }

        private void SetLayers(List<Image> layers)
        {
            _originalLayers = layers;
            _currentLayers = layers;

            int maxLayersWidth = _currentLayers.Max(l => l.Width);
            int maxLayersHigth = _currentLayers.Max(l => l.Height);
            _size = new Size(maxLayersWidth, maxLayersHigth);
        }

        public void Resize(int width, int height)
        {
            foreach (var layer in _currentLayers)
            {
                var destinationRectangle = new Rectangle(0, 0, width, height);
                var destinationImage = new Bitmap(width, height);

                destinationImage.SetResolution(layer.HorizontalResolution, layer.VerticalResolution);

                using (var graphics = Graphics.FromImage(destinationImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(layer, destinationRectangle, 0, 0, layer.Width, layer.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
            }
            _size = new Size(width, height);
        }

        public void Draw(Graphics graphics)
        {
            foreach (var layer in _currentLayers)
            {
                graphics.DrawImage(layer, new Rectangle(new Point(0, 0), new Size(_size.Width, _size.Height)));
            }
        }
    }
}

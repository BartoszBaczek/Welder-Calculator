using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class Chart
    {
        private List<Layer> _currentLayers;
        private readonly List<Layer> _originalLayers; 
        private Size _size;

        public List<Layer> Layers
        {
            get { return _currentLayers; }
        }

        public Chart(List<Layer> layers)
        {
            _originalLayers = layers;
            SetLayersVisibility();
        }

        public void Resize(int width, int height)
        {
            foreach (var layer in _currentLayers)
            {
                var destinationRectangle = new Rectangle(0, 0, width, height);
                var destinationImage = new Bitmap(width, height);

                destinationImage.SetResolution(layer.Image.HorizontalResolution, layer.Image.VerticalResolution);

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
                        graphics.DrawImage(layer.Image, destinationRectangle, 0, 0, layer.Image.Width, layer.Image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
            }
            _size = new Size(width, height);
        }

        public void Draw(Graphics graphics)
        {
            foreach (var layer in _currentLayers)
            {
                graphics.DrawImage(layer.Image, new Rectangle(new Point(0, 0), new Size(_size.Width, _size.Height)));
            }
        }

        public void HideLayer(LayerType type)
        {
            _currentLayers.RemoveAll(l => l.Type == type);
        }

        public void RestoreLayer(LayerType type)
        {
            _currentLayers.Add(
                _originalLayers
                .First( l=> l.Type == type));
        }

        private void SetLayersVisibility()
        {
            _currentLayers = _originalLayers;

            int maxLayersWidth = _currentLayers.Max(l => l.Image.Width);
            int maxLayersHigth = _currentLayers.Max(l => l.Image.Height);
            _size = new Size(maxLayersWidth, maxLayersHigth);
        }
    }
}

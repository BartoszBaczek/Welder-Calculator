using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace WelderCalculator.Drawings.Chart
{
    public class Chart
    {
        public Layers Layers { get; private set; }
        public Size Size { get; private set; }

        public Chart(Layers layers)
        {
            Layers = layers;
            SetLayersVisibility();
        }

        public void Resize(int width, int height)
        {
            foreach (var layer in Layers.GetActive())
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
            Size = new Size(width, height);
        }

        public void Draw(Graphics graphics)
        {
            foreach (var layer in Layers.GetActive())
            {
                graphics.DrawImage(layer.Image, new Rectangle(new Point(0, 0), new Size(Size.Width, Size.Height)));
            }
        }

        private void SetLayersVisibility()
        {
            int maxLayersWidth = Layers.GetActive().Max(l => l.Image.Width);
            int maxLayersHigth = Layers.GetActive().Max(l => l.Image.Height);
            Size = new Size(maxLayersWidth, maxLayersHigth);
        }
    }
}

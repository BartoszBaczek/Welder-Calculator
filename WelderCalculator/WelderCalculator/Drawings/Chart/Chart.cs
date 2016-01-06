﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using WelderCalculator.Drawings.Chart;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class Chart
    {
        private Layers _currentLayers;
        private readonly Layers _originalLayers; 
        private Size _size;

        public Layers Layers
        {
            get { return _currentLayers; }
        }

        public Chart(Layers layers)
        {
            _originalLayers = layers;
            SetLayersVisibility();
        }

        public void Resize(int width, int height)
        {
            foreach (var layer in _currentLayers.GetAll())
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
            foreach (var layer in _currentLayers.GetAll())
            {
                graphics.DrawImage(layer.Image, new Rectangle(new Point(0, 0), new Size(_size.Width, _size.Height)));
            }
        }

        private void SetLayersVisibility()
        {
            _currentLayers = _originalLayers;

            int maxLayersWidth = _currentLayers.GetAll().Max(l => l.Image.Width);
            int maxLayersHigth = _currentLayers.GetAll().Max(l => l.Image.Height);
            _size = new Size(maxLayersWidth, maxLayersHigth);
        }
    }
}

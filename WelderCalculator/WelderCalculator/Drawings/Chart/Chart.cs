﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace WelderCalculator.Drawings.Chart
{
    public class Chart
    {
        private Graphics _graphics;
        public Layers Layers { get; private set; }
        public Size Size { get; private set; }

        public Chart(Graphics graph, Layers layers)
        {
            _graphics = graph;
            Layers = layers;
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

        public void DrawLayers()
        {
            foreach (var layer in Layers.GetActive())
                _graphics.DrawImage(layer.Image, new Rectangle(new Point(0, 0), new Size(Size.Width, Size.Height)));
        }

        public void DrawPoints(IEnumerable<Point> p)
        {
            Point[] points = p.ToArray();
            Rectangle[] rectangles = new Rectangle[points.Count()];

            for (int i = 0; i < points.Count(); i++)
                rectangles[i] = new Rectangle(points[i], new Size(5, 5));

            foreach (var point in points)
                _graphics.FillRectangles(new SolidBrush(Color.Red), rectangles);
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using WelderCalculator.Model;

namespace WelderCalculator.Drawings.Chart
{
    public class Chart : IChart
    {
        //drawing tools
        private Pen _pen;
        private SolidBrush _solidBursh;
        private readonly ChartSizing _chartSizing;
        private readonly Graphics _graphics;
        private readonly List<DrawableRectangle> _drawableRectangles;
        private readonly List<DrawableLine> _drawableLines; 

        public Layers Layers { get; private set; }
        private PointF Size { get; set; }

        private bool _alreadyResized = false;

        private PointF Scale 
        {
            get { return new PointF(Size.X / _chartSizing.ImageWidthAndHeight.X, Size.Y / _chartSizing.ImageWidthAndHeight.Y); }
        }

        public Chart(Graphics graph, Layers layers, ChartSizing chartSizing)
        {
            _pen = new Pen(Color.White);
            _pen.Width = 3.0f;
            _solidBursh = new SolidBrush(Color.White);

            _chartSizing = chartSizing;

            _graphics = graph;
            Layers = layers;
            _drawableRectangles = new List<DrawableRectangle>();
            _drawableLines = new List<DrawableLine>();
        }


        public void ResizeTo(int width, int height)
        {
            if (!(_alreadyResized))
            {
                foreach (var layer in Layers.GetActive())
                {
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
                        }
                    }
                }
                Size = new PointF(width, height);

                ResizePoints();
                ResizeLines();

                _graphics.InterpolationMode = InterpolationMode.Bilinear;
            }

            _alreadyResized = true;
        }

        private void ResizePoints()
        {
            List<DrawableRectangle> oldDrawableRectangles = new List<DrawableRectangle>(_drawableRectangles);
            _drawableRectangles.Clear();

            foreach (var drawableRectangle in oldDrawableRectangles)
                AddPoint(drawableRectangle.OriginalPoint, drawableRectangle.Color);
        }

        private void ResizeLines()
        {
            List<DrawableLine> oldDrawableLines = new List<DrawableLine>(_drawableLines);
            _drawableLines.Clear();

            foreach (var drawableLine in oldDrawableLines)
                AddLine(drawableLine.PointToDraw1, drawableLine.POintToDraw2, drawableLine.Color);
        }


        public void Draw()
        {
            foreach (var layer in Layers.GetActive())
                _graphics.DrawImage(layer.Image, new Rectangle(new Point(0, 0), new Size((int) Size.X, (int) Size.Y)));

            
            foreach (var line in _drawableLines)
            {
                _pen.Color = line.Color;
                _graphics.DrawLine(_pen, line.OriginalPoint1, line.OriginalPoint2);
            }

            foreach (var rect in _drawableRectangles)
            {
                Rectangle tempRect = rect.Rectangle;
                tempRect.X -= (int)(tempRect.Width / 2.0f);
                tempRect.Y -= (int)(tempRect.Height / 2.0f);

                _solidBursh.Color = rect.Color;
                _graphics.FillRectangle(_solidBursh, tempRect);
            }
        }

        public void Clean()
        {
            _drawableRectangles.Clear();
            _drawableLines.Clear();
        }

        public void AddPoint(PointF point, Color color)
        {
            _drawableRectangles.Add(new DrawableRectangle(
                new Rectangle(ToBottomLeftOriginPoint(point), 
                new Size(7, 7)),
                color,
                point));
        }

        public void AddLine(PointF point1, PointF point2, Color color)
        {
            _drawableLines.Add(new DrawableLine(color,
                ToBottomLeftOriginPoint(point1),
                ToBottomLeftOriginPoint(point2),
                point1,
                point2));
        }

        private Point ToBottomLeftOriginPoint(PointF point)
        {
            PointF diagramScale = new PointF( (_chartSizing.ChartEndPointXandY.X - _chartSizing.ChartOriginXandY.X) / (_chartSizing.ChartEndInSpecialUnit.X - _chartSizing.ChartOriginInSpecialUnit.X), 
                (_chartSizing.ChartOriginXandY.Y - _chartSizing.ChartEndPointXandY.Y) / (_chartSizing.ChartEndInSpecialUnit.Y - _chartSizing.ChartOriginInSpecialUnit.Y));

            point.X *= diagramScale.X;
            point.Y *= diagramScale.Y;

            point = new PointF(
                (_chartSizing.ChartOriginXandY.X + point.X - _chartSizing.ChartOriginInSpecialUnit.X * diagramScale.X),
                (_chartSizing.ChartOriginXandY.Y - point.Y + _chartSizing.ChartOriginInSpecialUnit.Y * diagramScale.Y)
                );

            point.X *= Scale.X;
            point.Y *= Scale.Y;

            return new Point((int) point.X, (int) point.Y);
        }
    }
}

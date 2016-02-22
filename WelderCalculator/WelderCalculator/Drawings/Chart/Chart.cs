using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.Chart
{
    public class Chart
    {
        //TODO move to another class, or json file. Those data are valid only for schaeffler diagram
        private PointF _imageSize = new PointF(963, 863);
        private PointF _originPosition = new PointF(135.5f, 720);
        private PointF _maxPosition = new PointF(918, 38);
        private PointF _maxPositionValue = new PointF(32, 28);

        //drawables
        private Graphics _graphics;
        private List<DrawableRectangle> _drawableRectangles;
        private List<DrawableLine> _drawableLines; 

        public Layers Layers { get; private set; }

        public PointF Size { get; private set; }

        public PointF Scale 
        { 
            get { return new PointF(Size.X / _imageSize.X, Size.Y / _imageSize.Y); }
        }

        public Chart(Graphics graph, Layers layers)
        {
            _graphics = graph;
            Layers = layers;
            _drawableRectangles = new List<DrawableRectangle>();
            _drawableLines = new List<DrawableLine>();
        }


        public void Resize(int width, int height)
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

            foreach (var rect in _drawableRectangles)
            {
                Rectangle tempRect = rect.Rectangle;
                tempRect.X -=  (int) ((float)tempRect.Width /2.0f);
                tempRect.Y -= (int) ((float) tempRect.Height/2.0f);
                _graphics.FillRectangle(new SolidBrush(rect.Color), tempRect);
            }

            foreach (var line in _drawableLines)
                _graphics.DrawLine(new Pen(line.Color, 3.0f), line.OriginalPoint1, line.OriginalPoint2); 
        }

        public void Clean()
        {
            _drawableRectangles.Clear();
            _drawableLines.Clear();
        }

        public void AddPoint(PointF point, Color color)
        {
            Point pointInCoorectCoordinatesSystem = ToBottomLeftOriginPoint(point);

            _drawableRectangles.Add(new DrawableRectangle(
                new Rectangle(pointInCoorectCoordinatesSystem, new Size(7, 7)),
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
            PointF schaefflerDiagramScale = new PointF((918f - 138f) / 32f, (720f - 38f) / 28f);    //changes scale 0-28 or - 38

            point.X *= schaefflerDiagramScale.X;
            point.Y *= schaefflerDiagramScale.Y;

            point = new PointF(
                (_originPosition.X + point.X),
                (_originPosition.Y - point.Y)
                );

            point.X *= Scale.X;
            point.Y *= Scale.Y;

            return new Point((int) point.X, (int) point.Y);
        }
    }
}

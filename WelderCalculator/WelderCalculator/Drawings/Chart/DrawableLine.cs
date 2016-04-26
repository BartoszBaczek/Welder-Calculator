using System.Drawing;

namespace WelderCalculator.Drawings.Chart
{
    public class DrawableLine
    {
        public Color Color { get; private set; }
        public PointF PointToDraw1 { get; set; }
        public PointF POintToDraw2 { get; set; }
        public PointF OriginalPoint1 { get; set; }
        public PointF OriginalPoint2 { get; set; }

        public DrawableLine(Color color, PointF originalPoint1, PointF originalPoint2, PointF pointToDraw1, PointF pointToDraw2)
        {
            Color = color;

            OriginalPoint1 = originalPoint1;
            OriginalPoint2 = originalPoint2;

            PointToDraw1 = pointToDraw1;
            POintToDraw2 = pointToDraw2;
        }
    }
}

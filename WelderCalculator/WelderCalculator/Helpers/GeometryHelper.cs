using System.Drawing;

namespace WelderCalculator.Helpers
{
    public class GeometryHelper
    {
        static public PointF GetPointInTheMiddle(PointF point1, PointF point2)
        {
            return new PointF(0.5f * (point1.X + point2.X), 0.5f * (point1.Y + point2.Y));
        }

        // TODO this method propably works only, when point1
        // TODO is lower and left to point2. Needs testing.
        static public PointF GetPointInTheMiddleWithTranslation(double translation, PointF point1, PointF point2)
        {
            //transaltion should be number from 0 - 1.
            PointF point = new PointF(
                point1.X + (float) translation*(point2.X - point1.X),
                point1.Y + (float) translation*(point2.Y - point1.Y)
                );

            return point;
        }
    }
}

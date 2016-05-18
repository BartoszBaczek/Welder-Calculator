using System.Drawing;

namespace WelderCalculator.Helpers.DeLongHelpers
{
    public class DeLongMicrophaseHelper
    {
        private DeLongMicrophaseBorders _borders;

        public DeLongMicrophaseHelper()
        {
            _borders = new DeLongMicrophaseBorders();
        }

        public bool AMContains(PointF point)
        {
            return point.X >= 16f &&
                point.Y <= _borders.yInAmBorder(point.X) &&
                point.Y >= 10f;
        }

        public bool AContains(PointF point)
        {
            return point.X >= 16f &&
                point.Y <= 21f &&
                point.Y > _borders.yInAmBorder(point.X) &&
                point.Y > _borders.yIn0to2FBorder(point.X);
        }

        public bool F0to2Contains(PointF point)
        {
            return point.X >= 16f &&
                point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= _borders.yIn0to2FBorder(point.X) &&
                point.Y > _borders.yIn2to4FBorder(point.X);
        }

        public bool F2to4Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= _borders.yIn2to4FBorder(point.X) &&
                point.Y > _borders.yIn4to6FBorder(point.X);
        }

        public bool F4to6Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= _borders.yIn4to6FBorder(point.X) &&
                point.Y > _borders.yIn6to8FBorder(point.X);
        }

        public bool F6to8Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= _borders.yIn6to8FBorder(point.X) &&
                point.Y > _borders.yIn8to10FBorder(point.X);
        }

        public bool F8to10Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= _borders.yIn8to10FBorder(point.X) &&
                point.Y > _borders.yIn10to12Border(point.X);
        }

        public bool F10to12Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.Y <= 21f &&
                point.Y <= 27f &&
                point.Y <= _borders.yIn10to12Border(point.X) &&
                point.Y > _borders.yIn12to14FBorder(point.X);
        }

        public bool F12to14Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.X <= 27f &&
                point.Y <= _borders.yIn12to14FBorder(point.X) &&
                point.Y > _borders.yIn14to16FBorder(point.X);
        }

        public bool F14to16Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.X <= 27f &&
                point.Y <= _borders.yIn14to16FBorder(point.X) &&
                point.Y > _borders.yIn16to18FBorder(point.X);
        }

        public bool F16to18Contains(PointF point)
        {
            return point.Y >= 10f &&
                point.X <= 27f &&
                point.Y <= _borders.yIn16to18FBorder(point.X) &&
                point.Y > _borders.yIn18PlusFBorder(point.X);
        }

        public bool F18PlusContains(PointF point)
        {
            return point.Y >= 10f &&
                point.X <= 27f &&
                point.Y <= _borders.yIn18PlusFBorder(point.X);
        }
    }
}

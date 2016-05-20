using System.Drawing;

namespace WelderCalculator.Helpers.DeLongHelpers
{

    public enum DeLongMicrophase
    {
        A,
        AM,
        AMF,
        AF,
        Unknown
    }

    public enum DeLongFerriteQuantity
    {
        _0to2,
        _2to4,
        _4to6,
        _6to8,
        _8to10,
        _10to12,
        _12to14,
        _14to16,
        _16to18,
        _18Plus,
        Unknown
    }

    public class DeLongMicrophaseHelper
    {
        private DeLongMicrophaseBorders _borders;

        public DeLongMicrophaseHelper()
        {
            _borders = new DeLongMicrophaseBorders();
        }

        public DeLongFerriteQuantity GetFerriteQuantityForPoint(PointF point)
        {
            if (F0to2Contains(point))
                return DeLongFerriteQuantity._0to2;
            if (F2to4Contains(point))
                return DeLongFerriteQuantity._2to4;
            if (F4to6Contains(point))
                return DeLongFerriteQuantity._4to6;
            if (F6to8Contains(point))
                return DeLongFerriteQuantity._6to8;
            if (F8to10Contains(point))
                return DeLongFerriteQuantity._8to10;
            if (F10to12Contains(point))
                return DeLongFerriteQuantity._10to12;
            if (F12to14Contains(point))
                return DeLongFerriteQuantity._12to14;
            if (F14to16Contains(point))
                return DeLongFerriteQuantity._14to16;
            if (F16to18Contains(point))
                return DeLongFerriteQuantity._16to18;
            if (F18PlusContains(point))
                return DeLongFerriteQuantity._18Plus;
            else
                return DeLongFerriteQuantity.Unknown;
        }

        public DeLongMicrophase GetMicrophaseForPoint(PointF point)
        {
            if (AMContains(point) && GetFerriteQuantityForPoint(point) == DeLongFerriteQuantity.Unknown)
                return DeLongMicrophase.AM;
            if (AContains(point))
                return DeLongMicrophase.A;
            if (AMContains(point) && GetFerriteQuantityForPoint(point) != DeLongFerriteQuantity.Unknown)
                return DeLongMicrophase.AMF;
            if (!(AMContains(point)) && GetFerriteQuantityForPoint(point) != DeLongFerriteQuantity.Unknown)
                return DeLongMicrophase.AF;
            else
                return DeLongMicrophase.Unknown;
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

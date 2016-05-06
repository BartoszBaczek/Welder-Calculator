using System.Drawing;

namespace WelderCalculator.Helpers.SchaefflerHelpers
{
    public enum Microphase
    {
        FM, 
        M,
        AM,
        A,
        MF,
        AMF,
        AF,
        F,
        Unknown
    }

    public enum FerriteQuantity
    {
        _0to5,
        _5to10,
        _10to20,
        _20to40,
        _40to80,
        _80to100,
        Unknown
    }

    public class SchaefflerMicrophaseHelper
    {
        public  FerriteQuantity GetFerriteQuantityForPoint(PointF point)
        {
            if (F0to5Contains(point))
                return FerriteQuantity._0to5;
            if (F5to10Contains(point))
                return FerriteQuantity._5to10;
            if (F10to20Contains(point))
                return FerriteQuantity._10to20;
            if (F20to40Contains(point))
                return FerriteQuantity._20to40;
            if (F40to80Contains(point))
                return FerriteQuantity._40to80;
            if (F80to100Contains(point))
                return FerriteQuantity._80to100;
            else
                return FerriteQuantity.Unknown;
        }

        public Microphase GetMicrophaseForPoint(PointF point)
        {
            if (FMContainst(point))
                return Microphase.FM;
            if (MContains(point))
                return Microphase.M;
            if (AMContains(point))
                return Microphase.AM;
            if (AContains(point))
                return Microphase.A;
            if (MFContains(point))
                return Microphase.MF;
            if (AMFContains(point))
                return Microphase.AMF;
            if (AFContains(point))
                return Microphase.AF;
            if (FContains(point))
                return Microphase.F;
            else
                return Microphase.Unknown;
        }

        public bool FMContainst(PointF point)
        {
            return point.X >= 0 && 
                   point.Y >= 0 && 
                   point.X < (20.4f/6.8f) - (3/6.8f)*point.Y;
        }

        public bool MContains(PointF point)
        {
            return ((point.X >= 0f &&
                    point.X <= 3f &&
                    point.Y >= (20.4f/3f) - (6.8f/3f)*point.X &&
                    point.Y <= (96f/5f) - (4f/5f)*point.X)
                   ||
                   (point.X >= 3f &&
                    point.X <= 7.3f &&
                    point.Y >= 0f &&
                    point.Y <= (96f/5f) - (4f/5f)*point.X)
                   ||
                   (point.X >= 7.3f &&
                    point.Y <= 7.9f &&
                    point.X <= (153f/160f)*point.Y + (1072f/160))
                   ||
                   (point.X >= 7.3f &&
                    point.Y >= 7.9f &&
                    point.Y <= (96f/5f) - (4f/5f)*point.X));
        }

        public bool AMContains(PointF point)
        {
            return point.X >= 0 &&
                   point.Y >= (96f/5f) - (4f/5f)*point.X &&
                   point.X <= (153f/160f)*point.Y + (1072f/160f) &&
                   point.Y <= (126f/5f) - (4f/5f)*point.X;
        }

        public bool AContains(PointF point)
        {
            return ((point.X >= 0f &&
                     point.X <= 17.3f &&
                     point.Y <= 28f &&
                     point.Y >= (126f/5f) - (4f/5f)*point.X)
                    ||
                    (point.X >= 17.3f &&
                     point.X <= 32f &&
                     point.Y <= 28f &&
                     point.X <= (153f/160f)*point.Y + (1072f/160f)));
        }

        public bool MFContains(PointF point)
        {
            return point.Y >= 0 &&
                   point.Y <= (96f/5f) - (4f/5f)*point.X &&
                   point.X >= (153f/160f)*point.Y + (1072f/160f) &&
                   point.X <= (10f/3f)*point.Y + (34f/3f);
        }

        public bool FContains(PointF point)
        {
            return point.X <= 32f && 
                   point.Y >= 0f &&
                   point.X >= (10f / 3f) * point.Y + (34f / 3f);
        }

        public bool AMFContains(PointF point)
        {
            return point.Y >= (96f/5f) - (4f/5f)*point.X &&
                   point.X >= (153f/160f)*point.Y + (1072f/160f) &&
                   point.X <= (10f/3f)*point.Y + (34f/3f) &&
                   point.Y <= (126f/5f) - (4f/5f)*point.X;
        }

        public bool AFContains(PointF point)
        {
            return point.Y >= (126f/5f) - (4f/5f)*point.X &&
                   point.X <= 32f &&
                   point.X <= (10f/3f)*point.Y + (34f/3f) &&
                   point.X > (153f/160f)*point.Y + (1072f/160f);
        }

        public bool F0to5Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.X > (153f / 160f) * point.Y + (1072f / 160f) &&
                   point.X <= (1104f / 155f) + (160f / 155f) * point.Y;
        }

        public bool F5to10Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.X >= (1104f / 155f) + (160f / 155f) * point.Y &&
                   point.Y >= (17f / 20f) * point.X - (122f / 20f);
        }

        public bool F10to20Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.Y < (17f / 20f) * point.X - (122f / 20f) &&
                   point.X <= (70f / 51f) * point.Y + (442f / 51f);
        }

        public bool F20to40Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.X > (70f / 51f) * point.Y + (442f / 51f) &&
                   point.Y >= (83f / 130f) * point.X - (797f / 130f);
        }

        public bool F40to80Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.Y < (83f / 130f) * point.X - (797f / 130f) &&
                   point.X <= (10f / 5f) * point.Y + (51f / 5f);
        }

        public bool F80to100Contains(PointF point)
        {
            return point.Y >= (96f / 5f) - (4f / 5f) * point.X &&
                   point.X <= 32f &&
                   point.X > (10f / 5f) * point.Y + (51f / 5f) && 
                   point.X < (10f / 3f) * point.Y + (34f / 3f);
        }
    }
}

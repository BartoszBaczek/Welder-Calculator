using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Helpers.SchaefflerHelpers
{
    public class SchaefflerMicrophaseHelper
    {
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
            return false;
        }

        public bool F5to10Contains(PointF point)
        {
            return false;
        }

        public bool F10to20Contains(PointF point)
        {
            return false;
        }

        public bool F20to40Contains(PointF point)
        {
            return false;
        }

        public bool F40to80Contains(PointF point)
        {
            return false;
        }

        public bool F80to100Contains(PointF point)
        {
            return false;
        }
    }
}

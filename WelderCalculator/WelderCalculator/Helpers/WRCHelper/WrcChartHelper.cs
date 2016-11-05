using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Helpers.SchaefflerHelpers;

namespace WelderCalculator.Helpers.WRCHelper
{
    public enum WrcPhase
    {
        A, AF, FA, F, Unknown
    }

    public enum WrcFerriteQuantity
    {
        _0to4,
        _4to8,
        _8to12,
        _12to16,
        _16to20,
        _20to24,
        _24to28,
        _28to35,
        _35to55,
        _55to75,
        _75to95,
        _95to100,
        Unknown
    }

    public class WrcChartHelper
    {

        private WrcMicrophaseBorders _borders;

        public WrcChartHelper()
        {
            this._borders = new WrcMicrophaseBorders();
        }

        public WrcPhase GetWrcPhaseForForPoint(PointF point)
        {
            if (aContains(point))
                return WrcPhase.A;
            if (afContains(point))
                return WrcPhase.AF;
            if (faContains(point))
                return WrcPhase.FA;
            if (fContains(point))
                return WrcPhase.F;

            return WrcPhase.Unknown;
        }

        public WrcFerriteQuantity GetWrcFerriteQuantityForPoint(PointF point)
        {
            if (F0to4Contains(point))
                return WrcFerriteQuantity._0to4;
            if (F4to8Contains(point))
                return WrcFerriteQuantity._4to8;
            if (F8to12Contains(point))
                return WrcFerriteQuantity._8to12;
            if (F12to16Contains(point))
                return WrcFerriteQuantity._12to16;
            if (F16to20Contains(point))
                return WrcFerriteQuantity._16to20;
            if (F20to24Contains(point))
                return WrcFerriteQuantity._20to24;
            if (F24to28Contains(point))
                return WrcFerriteQuantity._24to28;
            if (F28to35Contains(point))
                return WrcFerriteQuantity._28to35;
            if (F35to55Contains(point))
                return WrcFerriteQuantity._35to55;
            if (F55to75Contains(point))
                return WrcFerriteQuantity._55to75;
            if (F75to95Contains(point))
                return WrcFerriteQuantity._75to95;
            if (F95to100Contains(point))
                return WrcFerriteQuantity._95to100;

            return WrcFerriteQuantity.Unknown;
        }

        public bool F0to4Contains(PointF point)
        {
            return basicContstrains(point) && 
                point.Y < _borders.y0(point.X) && 
                point.Y > _borders.y4(point.X);
        }

        public bool F4to8Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y4(point.X) &&
                point.Y > _borders.y8(point.X);
        }

        public bool F8to12Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y8(point.X) &&
                point.Y > _borders.y12(point.X);
        }

        public bool F12to16Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y12(point.X) &&
                point.Y > _borders.y16(point.X);
        }

        public bool F16to20Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y16(point.X) &&
                point.Y > _borders.y20(point.X);
        }

        public bool F20to24Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y20(point.X) &&
                point.Y > _borders.y24(point.X);
        }

        public bool F24to28Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y24(point.X) &&
                point.Y > _borders.y28(point.X);
        }

        public bool F28to35Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y28(point.X) &&
                point.Y > _borders.y35(point.X);
        }

        public bool F35to55Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y35(point.X) &&
                point.Y > _borders.y55(point.X);
        }

        public bool F55to75Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y55(point.X) &&
                point.Y > _borders.y75(point.X);
        }

        public bool F75to95Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y75(point.X) &&
                point.Y > _borders.y95(point.X);
        }

        public bool F95to100Contains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.y95(point.X) &&
                point.Y > _borders.y100(point.X);
        }

        private bool basicContstrains(PointF point)
        {
            return point.X > 17 && point.Y > 9 && point.X < 31 && point.Y < 18;
        }

        public bool aContains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y > _borders.aAndAfBorder(point.X);
        }

        public bool afContains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.aAndAfBorder(point.X) &&
                point.Y > _borders.afAndFaBorder(point.X);
        }

        public bool faContains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.afAndFaBorder(point.X) &&
                point.Y > _borders.faAndfBorder(point.X);
        }

        public bool fContains(PointF point)
        {
            return basicContstrains(point) &&
                point.Y < _borders.faAndfBorder(point.X);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Helpers.SchaefflerHelpers
{
    public class WrcMicrophaseBorders
    {
            public float y0(float x)
            {
                return 1.25f * x - 9.25f;
            }

            public float y4(float x)
            {
                return 1.16f * x - 9.83f;
            }

            public float y8(float x)
            {
                return 1.07f * x - 9.3f;
            }

            public float y12(float x)
            {
                return 1.07f * x - 10.38f;
            }

            public float y16(float x)
            {
                return 0.96f * x - 8.32f;
            }

            public float y20(float x)
            {
                return 1.04f * x - 11.16f;
            }

            public float y24(float x)
            {
                return 1.00f * x - 11.00f;
            }

            public float y28(float x)
            {
                return 1.00f * x - 11.6f;
            }

            public float y35(float x)
            {
                return 0.96f * x - 11.51f;
            }

            public float y55(float x)
            {
                return 0.80f * x - 8.81f;
            }

            public float y75(float x)
            {
                return 0.66f * x - 6.43f;
            }

            public float y95(float x)
            {
                return 0.52f * x - 3.91f;
            }

            public float y100(float x)
            {
            return 0.47f * x - 2.85f;
            }
    }
}

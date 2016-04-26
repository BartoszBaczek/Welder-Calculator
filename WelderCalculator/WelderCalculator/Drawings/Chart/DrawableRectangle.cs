﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Drawings.Chart
{
    public class DrawableRectangle
    {
        public Rectangle Rectangle { get; private set; }
        public Color Color { get; private set; }
        public PointF OriginalPoint { get; set; }

        public DrawableRectangle(Rectangle rect, Color color, PointF originalPoint)
        {
            Rectangle = rect;
            Color = color;
            OriginalPoint = originalPoint;
        }
    }
}

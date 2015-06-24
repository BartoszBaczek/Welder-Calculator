using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WelderCalculator.Model
{
    public interface IElement
    {
        float? Max { get; }

        float? Min { get; }

        float? Average { get; }

        bool HasValue { get; }


        void SetRange(float? min, float? max);
    }
}

using System;
using System.Linq.Expressions;

namespace WelderCalculator.Model
{
    public class Element : IElement
    {
        public float? Max { get; private set; }

        public float? Min { get; private set; }

        public float? Average { get; private set; }

        public bool HasValue { get; private set; }


        public void SetRange(float? min, float? max)
        {
            if (min >= max)
                throw new ElementException("Min must be greater than max!");
            else if (min < 0f || max < 0f)
                throw new ElementException("Min/max must be greater than 0!");
            else if (min > 100f || max > 100f)
                throw new ElementException("Min/max must be lesser than 0!");
            else
            {
                Min = min;
                Max = max;
                Average = (min + max)/2f;
                HasValue = true;
                
            }
        }

    }
}
//TODO:
/*
 * 1) Napisać test dla przypadku:
 * var e = new Element();
 * e.SetRange(1f, 10f);
 * e.SetRange(null, null);
 *  - Czy wtedy Average będzie znów nullem?
 *  - czy HasValue wróci na False?
 *  
 * 2) Ogarnąć Wyjątki. Jak się to robi profesjonalnie?
 * 3) SetRange(min, max)
 * {
 *  if (min == null && max == null) {   }
 *  if (min == null && max != null) {   }
 *  if (min != null && max == null) {   }
 *  if *min != null && max != null) {   }
 * }

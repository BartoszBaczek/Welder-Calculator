using System.Collections.Generic;

namespace WelderCalculator.Model
{
    public class BaseNorm : Norm
    {
        public List<BaseMaterial> Materials { get; set; }

        public BaseNorm() : base()
        {
            Materials = new List<BaseMaterial>();
        }
    }
}

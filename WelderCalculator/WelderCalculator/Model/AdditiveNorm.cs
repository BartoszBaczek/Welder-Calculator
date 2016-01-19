using System.Collections.Generic;

namespace WelderCalculator.Model
{
    public class AdditiveNorm : Norm
    {
        public List<AdditiveMaterial> Materials { get; set; }

        public AdditiveNorm() : base()
        {
            Materials = new List<AdditiveMaterial>();
        }
    }
}

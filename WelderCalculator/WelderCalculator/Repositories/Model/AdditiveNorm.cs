using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories.Model
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

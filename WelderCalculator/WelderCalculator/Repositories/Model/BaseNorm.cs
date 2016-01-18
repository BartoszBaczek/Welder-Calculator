using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories.Model
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

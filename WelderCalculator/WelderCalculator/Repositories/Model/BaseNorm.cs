using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp;

namespace WelderCalculator.Repositories.Model.temp2
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

 using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WelderCalculator.Model
{
    public class MaterialNorm
    {
        public string Name { get; set; }

        public List<Material> Materials { get; set; }

        public MaterialNorm()
        {
            Name = string.Empty;
            Materials = new List<Material>();
        }
    }
}

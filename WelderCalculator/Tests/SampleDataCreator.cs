using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using WelderCalculator.Model;
using WelderCalculator.Serialization;

namespace Tests
{
    public class SampleDataCreator
    {
        public MaterialNorm GetSampleMaterialNorm()
        {
            #region Create 3 sample materials
            //given
            var material1 = new Material { Name = "material2", Number = "123" };
            foreach (var e in material1.Elements)
            {
                e.Max = 0.5;
                e.Min = 0.4;
                e.RealValue = 0.47;
            }

            var material2 = new Material { Name = "material3", Number = "456" };
            foreach (var e in material2.Elements)
            {
                e.Max = 0.9;
                e.Min = 0.8;
                e.RealValue = 0.85;
            }

            var material3 = new Material {Name = "material1", Number = "789"};
            foreach (var e in material3.Elements)
            {
                e.Max = 0.2;
                e.Min = 0.1;
                e.RealValue = 0.15;
            }
            #endregion

            var sampleMaterialNorm1 = new MaterialNorm {Name = "sampleMaterialNorm1"};
            sampleMaterialNorm1.Materials.Add(material1);
            sampleMaterialNorm1.Materials.Add(material2);
            sampleMaterialNorm1.Materials.Add((material3));

            return sampleMaterialNorm1;
        }

        public Material GetSampleMaterial()
        {
            var material = new Material { Name = "material1", Number = "123" };
            foreach (var e in material.Elements)
            {
                e.Max = 0.5;
                e.Min = 0.4;
                e.RealValue = 0.47;
            }

            return material;
        }
    }
}

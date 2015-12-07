using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp;
using WelderCalculator.Repositories.Model.temp2;

namespace Tests
{
    public class SampleDataCreator
    {
        public BaseNorm GetSampleMaterialNorm()
        {
            #region Create 3 sample materials
            //given
            var material1 = new BaseMaterial() { Name = "material2", Number = "123" };
            material1.CreateBasicListOfElements();

            foreach (var e in material1.Elements)
            {
                e.Max = 0.5;
                e.Min = 0.4;
                e.RealValue = 0.47;
            }

            var material2 = new BaseMaterial { Name = "material3", Number = "456" };
            material2.CreateBasicListOfElements();
            foreach (var e in material2.Elements)
            {
                e.Max = 0.9;
                e.Min = 0.8;
                e.RealValue = 0.85;
            }

            var material3 = new BaseMaterial {Name = "material1", Number = "789"};
            material3.CreateBasicListOfElements();
            foreach (var e in material3.Elements)
            {
                e.Max = 0.2;
                e.Min = 0.1;
                e.RealValue = 0.15;
            }
            #endregion

            var sampleMaterialNorm1 = new BaseNorm() {Name = "sampleMaterialNorm1"};
            sampleMaterialNorm1.Materials.Add(material1);
            sampleMaterialNorm1.Materials.Add(material2);
            sampleMaterialNorm1.Materials.Add((material3));

            return sampleMaterialNorm1;
        }

        public BaseMaterial GetSampleMaterial()
        {
            var material = new BaseMaterial() { Name = "material1", Number = "123" };
            material.CreateBasicListOfElements();

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

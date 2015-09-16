using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using WelderCalculator.Model;
using WelderCalculator.Serialization;


namespace Tests
{
    [TestFixture]
    public class MaterialTests
    {
        private Material sampleMaterial;

        [SetUp]
        public void Init()
        {
            var dataCreator = new SampleDataCreator();
            sampleMaterial = dataCreator.GetSampleMaterial();
        }

        [Test]
        public void ShouldGetValuesOfMateiralElement()
        {
            //given
            Element expectedElement = new Element(Category.OfElement.C)
            {
                Min = 12.4d,
                Max =  16.1d,
                RealValue = 14d
            };

            //when
            Element sampleMaterialElement = sampleMaterial.GetElement(Category.OfElement.C);
            sampleMaterialElement.Min = 12.4;
            sampleMaterialElement.Max = 16.1;
            sampleMaterialElement.RealValue = 14d;

            //then
            Assert.IsTrue(
                   sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Min == expectedElement.Min
                && sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Max == expectedElement.Max
                && sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).RealValue == expectedElement.RealValue);
        }

        [Test]
        public void ShouldChangeValueOfMaterialElement()
        {
            //given
            Element expectedElement = new Element(Category.OfElement.C)
            {
                Min = 5.1d,
                Max = 6.3d,
                RealValue = 5.4d
            };

            //when
            Element sampleMaterialElement = sampleMaterial.GetElement(Category.OfElement.C);
            sampleMaterialElement.Min = 12.4;
            sampleMaterialElement.Max = 16.1;
            sampleMaterialElement.RealValue = 14d;

            sampleMaterial.GetElement(Category.OfElement.C).Min = 5.1d;
            sampleMaterial.GetElement(Category.OfElement.C).Max = 6.3d;
            sampleMaterial.GetElement(Category.OfElement.C).RealValue = 5.4d;

            //then
            Assert.IsTrue(
                   sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Min == expectedElement.Min
                && sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Max == expectedElement.Max
                && sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).RealValue == expectedElement.RealValue);
        }
    }
}

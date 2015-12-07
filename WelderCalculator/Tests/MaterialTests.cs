using System.Linq;
using NUnit.Framework;
using WelderCalculator.Model;


namespace Tests
{
    [TestFixture]
    public class MaterialTests
    {
        private Material _sampleMaterial;
        private SampleDataCreator _dataCreator;
        [SetUp]
        public void Init()
        {
            _dataCreator = new SampleDataCreator();
            _sampleMaterial = _dataCreator.GetSampleMaterial();
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
            Element sampleMaterialElement = _sampleMaterial.GetElement(Category.OfElement.C);
            sampleMaterialElement.Min = 12.4;
            sampleMaterialElement.Max = 16.1;
            sampleMaterialElement.RealValue = 14d;

            //then
            Assert.IsTrue(
                   _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Min == expectedElement.Min
                && _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Max == expectedElement.Max
                && _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).RealValue == expectedElement.RealValue);
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
            Element sampleMaterialElement = _sampleMaterial.GetElement(Category.OfElement.C);
            sampleMaterialElement.Min = 12.4;
            sampleMaterialElement.Max = 16.1;
            sampleMaterialElement.RealValue = 14d;

            _sampleMaterial.GetElement(Category.OfElement.C).Min = 5.1d;
            _sampleMaterial.GetElement(Category.OfElement.C).Max = 6.3d;
            _sampleMaterial.GetElement(Category.OfElement.C).RealValue = 5.4d;

            //then
            Assert.IsTrue(
                   _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Min == expectedElement.Min
                && _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).Max == expectedElement.Max
                && _sampleMaterial.Elements.First(e => e.Name == Category.OfElement.C).RealValue == expectedElement.RealValue);
        }

        [Test]
        public void ShouldGenerateTwoDifferentGuidValues()
        {
            //given
            var material1 = _dataCreator.GetSampleMaterial();
            var material2 = _dataCreator.GetSampleMaterial();

            var material1_GUID = material1.GuidNumber;
            var material2_GUID = material2.GuidNumber;

            //when
            bool guidsAreDifferent = !(material1_GUID.Equals(material2_GUID));

            //then
            Assert.IsTrue(guidsAreDifferent);
        }

        [Test]
        public void ShouldReturnTrueAsTwoMaterialsAreTheSame()
        {
            //given
            Material material1 = _dataCreator.GetSampleMaterial();
            Material material2 = _dataCreator.GetSampleMaterial();

            //when
            bool materialsAreTheSame = material1.Equals(material2);

            //then
            Assert.IsTrue(materialsAreTheSame);
        }

        [Test]
        public void ShouldReturnFalseAsTwoMaterialsAreDifferent()
        {
            //given
            Material material1 = _dataCreator.GetSampleMaterial();
            Material material2 = _dataCreator.GetSampleMaterial();
            material2.GetElement(Category.OfElement.Si).Min = 0.99999;

            //when
            bool materialsAreTheSame = material1.Equals(material2);

            //then
            Assert.IsFalse(materialsAreTheSame);
        }
    }
}

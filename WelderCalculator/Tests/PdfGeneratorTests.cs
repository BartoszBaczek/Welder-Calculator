using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;
using WelderCalculator.PDFUtilities;

namespace Tests
{
    [TestFixture]
    public class PDFGeneratorTests
    {
        private SampleDataCreator _dataCreator = new SampleDataCreator();

        private BaseMaterial _baseMaterial1;

        private BaseMaterial _baseMaterial2;

        private AdditiveMaterial _addMaterial;

        [SetUp]
        public void Init()
        {
            _baseMaterial1 = _dataCreator.GetSampleMaterial();
            _baseMaterial2 = _dataCreator.GetSampleMaterial();
            _addMaterial = _dataCreator.GetAdditiveMaterial();
        }

        [Test]
        public void ShouldGeneratePDF()
        {
            PDFGenerator pdf = new PDFGenerator(PdfFor.Schaeffler, _baseMaterial1, _baseMaterial2, _addMaterial, 25, "BARDZO DUZO");
            Assert.IsTrue(false);
        }
    }
}

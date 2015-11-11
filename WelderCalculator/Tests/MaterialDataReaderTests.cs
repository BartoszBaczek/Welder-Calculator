using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using WelderCalculator.Model;


namespace Tests
{
    [TestFixture]
    public class MaterialDataReaderTests
    {
        private MaterialDataConnector _dataConnector;
        private SampleDataCreator _dataCreator;

        [SetUp]
        public void Init()
        {
            _dataConnector = new MaterialDataConnector("chuj");
            _dataCreator = new SampleDataCreator();
        }
        
        [Test]
        public void ShouldReturnOnlyNamesOfMaterialNormsInAlphabeticalOrder()
        {
            //given
            List<string> expectedListOfNames = new List<string>()
            {
                "sampleMaterialNorm1",
                "sampleMaterialNorm2"
            };

            //when
            List<string> listOfNorms = _dataConnector.GetSortedListOfMaterialsNormsNames();

            //then
            CollectionAssert.AreEqual(listOfNorms, expectedListOfNames);
        }

        [Test]
        public void ShouldReturnSortedListOfMaterialsInNorm()
        {
            //given
            string[] expectedMaterialsNames = {"material1", "material2", "material3"};

            //when
            List<Material> materials = _dataConnector.GetListOfMaterialsFromNorm("sampleMaterialNorm1");

            bool materialsAreInAlphabeticalOrder = materials[0].Name == expectedMaterialsNames[0]
                                                && materials[1].Name == expectedMaterialsNames[1]
                                                && materials[2].Name == expectedMaterialsNames[2];

            //then
            Assert.That(materialsAreInAlphabeticalOrder);
        }
    }
}

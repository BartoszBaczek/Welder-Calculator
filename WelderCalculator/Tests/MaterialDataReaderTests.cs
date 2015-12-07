using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp;


namespace Tests
{
    [TestFixture]
    public class MaterialDataReaderTests
    {
        private DataConnector _dataConnector;
        private SampleDataCreator _dataCreator;

        [SetUp]
        public void Init()
        {
            _dataConnector = new DataConnector("saf");
            _dataCreator = new SampleDataCreator();
        }
        
        [Test]
        public void ShouldReturnOnlyNamesOfMaterialNormsInAlphabeticalOrder()
        {
            //given
            List<string> expectedListOfNames = new List<string>()
            {
                "allahuakbar",
                "sampleMaterialNorm1"
            };

            //when
            List<string> listOfNorms = _dataConnector.GetNamesOfAllNorms();

            //then
            CollectionAssert.AreEqual(listOfNorms, expectedListOfNames);
        }

        [Test]
        public void ShouldReturnSortedListOfMaterialsInNorm()
        {
            //given
            string[] expectedMaterialsNames = {"material1", "material2", "material3"};

            //when
            List<BaseMaterial> materials = _dataConnector.GetMaterialsFromNorm("sampleMaterialNorm1");

            bool materialsAreInAlphabeticalOrder = materials[0].Name == expectedMaterialsNames[0]
                                                && materials[1].Name == expectedMaterialsNames[1]
                                                && materials[2].Name == expectedMaterialsNames[2];
            for (int i = 0; i < materials.Count; i++)
                Debug.WriteLine(materials[i].Name + "      " + expectedMaterialsNames[i]);
            //then
            Assert.That(materialsAreInAlphabeticalOrder);
        }
    }
}

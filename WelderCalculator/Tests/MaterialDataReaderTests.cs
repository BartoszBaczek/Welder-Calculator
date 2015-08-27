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
        private MaterialDataReader _dataReader;

        [SetUp]
        public void Init()
        {
            _dataReader = new MaterialDataReader("chuj");
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
            List<string> listOfNorms = _dataReader.GetSortedListOfMaterialsNorms();

            //then
            CollectionAssert.AreEqual(listOfNorms, expectedListOfNames);
        }
    }
}

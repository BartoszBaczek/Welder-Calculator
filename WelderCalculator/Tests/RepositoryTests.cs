using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using WelderCalculator.Model;
using WelderCalculator.Serialization;


namespace Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private IRepository _repo;
        private SampleDataCreator _dataCreator;
        [SetUp]
        public void Init()
        {
            _repo = new Repository("some fucking path");
            _dataCreator = new SampleDataCreator();
        }

        [Test]
        public void ShouldSerializeNewFileWhenMaterialNormSaved()
        {
            //given
            var testMaterialNorm = _dataCreator.GetSampleMaterialNorm();

            //when
            _repo.SaveToFile(testMaterialNorm);

            //then
            Assert.IsFalse(false);
        }

        [Test]
        public void ShouldReturnArrayOfFilesInFolder()
        {
            //given
            string[] expectedResult = new[]
            {
                "sampleMaterialNorm1",
                "sampleMaterialNorm2"
            };

            string[] anotherExpectedResult = new[]
            {
                "sampleMaterialNorm2",
                "sampleMaterialNorm1"
            };

            //when
            string[] returnedListOfFiles = _repo.GetNamesOfFilesInDataFolder();
            
            //then
            if (returnedListOfFiles[0] == expectedResult[0])
                CollectionAssert.AreEqual(returnedListOfFiles, expectedResult);
            else if (returnedListOfFiles[0] == anotherExpectedResult[0])
                CollectionAssert.AreEqual(returnedListOfFiles, anotherExpectedResult);
        }

        [Test]
        public void ShouldGetMaterialNormByName()
        {
            //given
            MaterialNorm expectedNorm = _dataCreator.GetSampleMaterialNorm();
            int expectedNumberOfMaterialsInNorm = expectedNorm.Materials.Count;
            string expectedNormName = expectedNorm.Name;

            string[] expectedMaterialName = {"material2", "material3", "material1"};
            
            //when
            MaterialNorm norm = _repo.GetNorm("sampleMaterialNorm1");

            bool materials = (norm.Materials[0].Name == expectedMaterialName[0]
                                        && norm.Materials[1].Name == expectedMaterialName[1]
                                        && norm.Materials[2].Name == expectedMaterialName[2]

                                        && norm.Materials.Count == expectedNumberOfMaterialsInNorm);
            
            //then
            Assert.IsTrue(norm.Name == expectedNormName && materials);
        }
    }
}

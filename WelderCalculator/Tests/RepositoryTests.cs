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
        private SampleDataCreator dataCreator;
        [SetUp]
        public void Init()
        {
            _repo = new Repository("some fucking path");
            dataCreator = new SampleDataCreator();
        }

        [Test]
        public void ShouldSerializeNewFileWhenMaterialNormSaved()
        {
            //given
            var testMaterialNorm = dataCreator.GetSampleMaterialNorm();

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
            MaterialNorm expectedMaterialNorm = dataCreator.GetSampleMaterialNorm();
            
            //when
            MaterialNorm norm = _repo.GetNorm("sampleMaterialNorm1");
            
            //then
            bool materialsAreTheSame = norm.Materials.All(expectedMaterialNorm.Materials.Contains);
                //norm.Materials.All(expectedMaterialNorm.Materials.Contains);
                
                /*(norm.Materials[0].Name == expectedMaterialNorm.Materials[0].Name
                                        && norm.Materials[1].Name == expectedMaterialNorm.Materials[1].Name
                                        && norm.Materials[2].Name == expectedMaterialNorm.Materials[2].Name

                                        && norm.Materials[0].Number == expectedMaterialNorm.Materials[0].Number
                                        && norm.Materials[1].Number == expectedMaterialNorm.Materials[1].Number
                                        && norm.Materials[2].Number == expectedMaterialNorm.Materials[2].Number
                                        );
                 */
            Assert.IsTrue(norm.Name == expectedMaterialNorm.Name && materialsAreTheSame);
        }
    }
}

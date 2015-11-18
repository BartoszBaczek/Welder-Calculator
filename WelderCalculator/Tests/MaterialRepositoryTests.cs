using System.Diagnostics;
using System.Linq;
using NUnit.Core;
using NUnit.Framework;
using WelderCalculator.Model;
using WelderCalculator.Serialization;


namespace Tests
{
    [TestFixture]
    public class MaterialRepositoryTests
    {
        private IMaterialRepository _repo;
        private SampleDataCreator _dataCreator;
        [SetUp]
        public void Init()
        {
            _repo = new MaterialRepository("some fucking path");
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

        [Test]
        public void ShouldNotChangeMaterialGUIDWhenDeserializingMaterial()
        {
            //given
            Material material1 = _dataCreator.GetSampleMaterial();
            Debug.WriteLine("Guid1:   " + material1.GuidNumber);

            MaterialNorm materialNorm = new MaterialNorm();
            materialNorm.Name = "allahuakbar";
            materialNorm.Materials.Add(material1);

            //when
            _repo.SaveToFile(materialNorm);
            MaterialNorm newMaterialNorm = _repo.GetNorm("allahuakbar");
            Debug.WriteLine("Guid2:   " + newMaterialNorm.Materials[0].GuidNumber);


            string guid1 = material1.GuidNumber.ToString();
            string guid2 = materialNorm.Materials[0].GuidNumber.ToString();
            //then

            Assert.AreEqual(guid1, guid2);
        }

        [Test]
        public void ShouldGetMaterialByGuidAndNormName()
        {
            
        }
    }
}

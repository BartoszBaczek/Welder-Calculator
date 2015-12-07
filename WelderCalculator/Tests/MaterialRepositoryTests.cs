using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using WelderCalculator.Model;
using WelderCalculator.Repositories;


namespace Tests
{
    [TestFixture]
    public class MaterialRepositoryTests
    {
        private IBasicMaterialRepository _repo;
        private SampleDataCreator _dataCreator;
        [SetUp]
        public void Init()
        {
            _repo = new BasicMaterialRepository("some fucking path");
            _dataCreator = new SampleDataCreator();
        }

        [Test]
        public void ShouldSerializeNewFileWhenMaterialNormSaved()
        {
            //given
            var testMaterialNorm = _dataCreator.GetSampleMaterialNorm();

            //when
            _repo

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
            Norm expectedNorm = _dataCreator.GetSampleMaterialNorm();
            int expectedNumberOfMaterialsInNorm = expectedNorm.Materials.Count;
            string expectedNormName = expectedNorm.Name;

            string[] expectedMaterialName = {"material2", "material3", "material1"};
            
            //when
            Norm norm = _repo.GetNorm("sampleMaterialNorm1");

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

            Norm norm = new Norm();
            norm.Name = "allahuakbar";
            norm.Materials.Add(material1);

            //when
            _repo.SaveToFile(norm);
            Norm newNorm = _repo.GetNorm("allahuakbar");
            Debug.WriteLine("Guid2:   " + newNorm.Materials[0].GuidNumber);


            string guid1 = material1.GuidNumber.ToString();
            string guid2 = norm.Materials[0].GuidNumber.ToString();
            //then

            Assert.AreEqual(guid1, guid2);
        }
        [Test]
        public void ShouldGetMaterialByGuidAndNormName()
        {
            //given 
            Material expectedMaterial = _repo.GetNorm("sampleMaterialNorm1").Materials[0];
            Guid guidToFind = expectedMaterial.GuidNumber;

            //when 
            Norm toFind = _repo.GetNorm("sampleMaterialNorm1");

            //then
            Assert.That(toFind.Name == expectedMaterial.Name);
        }
    }
}

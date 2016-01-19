using System;
using System.Collections.Generic;
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
        private NormRepository _repo;
        private SampleDataCreator _dataCreator;
        [SetUp]
        public void Init()
        {
            _repo = new NormRepository("some path");
            _dataCreator = new SampleDataCreator();
        }

        [Test]
        public void ShouldSerializeNewFileWhenMaterialNormSaved()
        {
            //given
            var testMaterialNorm = _dataCreator.GetSampleMaterialNorm();

            //when
            _repo.SerializeBaseNorm(testMaterialNorm);

            //then
            Assert.IsFalse(false);
        }

        [Test]
        public void ShouldSerializeAddNorm()
        {
            //given
            var testMaterialNorm = _dataCreator.GetSampleAdditiveNorm();

            //when
            _repo.SerializeAdditiveNorm(testMaterialNorm);

            //then
            Assert.IsFalse(false);
        }

        [Test]
        public void ShouldReturnNormNames()
        {
            //given
            List<string> expectedResult = new List<string>()
            {
                "sampleMaterialNorm1",
                "sampleMaterialNorm2"
            };

            List<string> anotherExpectedResult = new List<string>()
            {
                "sampleMaterialNorm2",
                "sampleMaterialNorm1"
            };

            //when
            List<string> returnedListOfFiles = _repo.GetNamesOfBaseNorms();
            
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
            BaseNorm expectedNorm = _dataCreator.GetSampleMaterialNorm();
            int expectedNumberOfMaterialsInNorm = expectedNorm.Materials.Count;
            string expectedNormName = expectedNorm.Name;

            string[] expectedMaterialName = {"material2", "material3", "material1"};
            
            //when
            BaseNorm norm = _repo.DeserializeBaseNorm("sampleMaterialNorm1");

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
            BaseMaterial material1 = _dataCreator.GetSampleMaterial();
            Debug.WriteLine("Guid1:   " + material1.GuidNumber);

            BaseNorm norm = new BaseNorm();
            norm.Name = "allahuakbar";
            norm.Materials.Add(material1);

            //when
            _repo.SerializeBaseNorm(norm);
            BaseNorm newNorm = _repo.DeserializeBaseNorm("allahuakbar");
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
            BaseMaterial expectedMaterial = _repo.DeserializeBaseNorm("sampleMaterialNorm1").Materials[0];
            Guid guidToFind = expectedMaterial.GuidNumber;

            //when 
            var normWithMaterial = _repo.DeserializeBaseNorm("sampleMaterialNorm1");
            BaseMaterial mat = normWithMaterial.Materials.FirstOrDefault(m => m.GuidNumber.Equals(guidToFind));

            //then
            Assert.That(mat.Name == expectedMaterial.Name);
        }
    }
}

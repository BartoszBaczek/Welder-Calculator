
using System;
using System.Collections.Generic;
using System.Linq;
using WelderCalculator.Serialization;

namespace WelderCalculator.Model
{
    public class MaterialDataConnector
    {
        private readonly IMaterialRepository _repository;

        public MaterialDataConnector()
        {
            _repository = new MaterialRepository();
        }

        /*Use this constructor ONLY for testing!!!*/
        public MaterialDataConnector(string filePathForTestsOnly)
        {
            _repository = new MaterialRepository(filePathForTestsOnly);
        }

        public List<string> GetSortedListOfMaterialsNormsNames()
        {
            string[] filesNames = _repository.GetNamesOfFilesInDataFolder();
            List<string> sortedListOfFiles = filesNames.OrderBy(q => q).ToList();

            return sortedListOfFiles;
        }

        public List<Material> GetListOfMaterialsFromNorm(string normName)
        {
            MaterialNorm norm = _repository.GetNorm(normName);

            List<Material> sortedListOfMaterials = norm.Materials.OrderBy(q => q.Name).ToList();

            return sortedListOfMaterials;
        }

        public List<Category.OfElement> GetLastSavedOrderOfElements()
        {
            return _repository.GetOrderOfElements();
        }

        public Material GetMaterial(Guid guid, string materialNormName)
        {
            return _repository.GetMaterialByGUID(guid, materialNormName);
        }

        public MaterialNorm GetNorm(string normName)
        {
            MaterialNorm requestedNorm = _repository.GetNorm(normName);

            return requestedNorm;
        }
    }
}

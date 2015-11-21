
using System;
using System.Collections.Generic;
using System.Linq;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Serialization;

namespace WelderCalculator.Model
{
    public class MaterialModificationDataConnector
    {
        private readonly IMaterialModificationRepository _repository;

        public MaterialModificationDataConnector()
        {
            _repository = new MaterialModificationRepository();
        }

        /*Use this constructor ONLY for testing!!!*/
        public MaterialModificationDataConnector(string filePathForTestsOnly)
        {
            _repository = new MaterialModificationRepository(filePathForTestsOnly);
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

using System;
using System.Collections.Generic;
using System.Linq;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Repositories.Model.temp;
using WelderCalculator.Repositories.Model.temp2;

namespace WelderCalculator.MaterialModificationView.Serialization
{
    public class DataConnector
    {
        private NormRepository _normRepo;


        public DataConnector()
        {
            _normRepo = new NormRepository();
        }

        //temp method for tests only
        public DataConnector(string test)
        {
            _normRepo = new NormRepository("dsf");
        }

        public BaseMaterial GetBaseMaterial(Guid guid, string normName)
        {
            var normWithMaterial = _normRepo.DeserializeBaseNorm(normName);
            return normWithMaterial.Materials.FirstOrDefault(m => m.GuidNumber.Equals(guid));
        }

        public void RemoveBaseNorm(string normName)
        {
            _normRepo.DeleteBaseNorm(normName);
        }

        public void SaveBaseNorm(BaseNorm norm)
        {
            _normRepo.SerializeBaseNorm(norm);
        }

        public BaseNorm GetBaseNorm(string normName)
        {
            return _normRepo.DeserializeBaseNorm(normName);
        }

        public List<Category.OfElement> GetOrderOfElementsForBaseMaterial()
        {
            List<Category.OfElement> order = _normRepo.DeserializeBaseNormsProperties();
            return order;
        }

        public void SaveBaseNormProperties(List<Category.OfElement> orderOfElements)
        {
            _normRepo.SerializeBaseNormsProperties(orderOfElements);
        }

        public List<string> GetNamesOfBaseNorms()
        {
            return _normRepo.GetNamesOfBaseNorms();
        }

        public List<BaseMaterial> GetBaseMaterials(string normName)
        {
            BaseNorm norm = _normRepo.DeserializeBaseNorm(normName);
            return norm.Materials.OrderBy(m => m.Name).ToList();
        }
    }
}

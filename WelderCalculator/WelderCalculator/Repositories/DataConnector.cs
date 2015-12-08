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
        private BasicMaterialRepository _repo;

        public DataConnector()
        {
            _repo = new BasicMaterialRepository();
        }

        //temp method for tests only
        public DataConnector(string test)
        {
            _repo = new BasicMaterialRepository("dsf");
        }

        public BaseMaterial GetMaterial(Guid guid, string normName)
        {
            var normWithMaterial = _repo.DeserializeNorm(normName);
            return normWithMaterial.Materials.FirstOrDefault(m => m.GuidNumber.Equals(guid));
        }

        public void RemoveNorm(string normName)
        {
            _repo.DeleteNorm(normName);
        }

        public void SaveNorm(BaseNorm norm)
        {
            _repo.SerializeNorm(norm);
        }

        public BaseNorm GetNorm(string normName)
        {
            return _repo.DeserializeNorm(normName);
        }

        //public List<string> GetOrderOfElements()
        //{
        //    List<Category.OfElement> order = _repo.DeserializeProperties();
        //    return order.Select(obj => obj.ToString()).ToList();
        //}

        public List<Category.OfElement> GetOrderOfElements()
        {
            List<Category.OfElement> order = _repo.DeserializeProperties();
            return order;
        }

        public void SaveProperties(List<Category.OfElement> orderOfElements)
        {
            _repo.SerializeProperties(orderOfElements);
        }

        public List<string> GetNamesOfAllNorms()
        {
            return _repo.GetNamesOfNorms();
        }

        public List<BaseMaterial> GetMaterialsFromNorm(string normName)
        {
            BaseNorm norm = _repo.DeserializeNorm(normName);
            return norm.Materials.OrderBy(m => m.Name).ToList();
        }
    }
}

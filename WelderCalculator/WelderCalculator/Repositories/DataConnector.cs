using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.MaterialModificationView.Serialization
{
    public class DataConnector
    {
        private BasicMaterialRepository _repo;

        public DataConnector()
        {
            _repo = new BasicMaterialRepository();
        }

        public Material GetMaterial(Guid guid, string normName)
        {
            var normWithMaterial = _repo.DeserializeNorm(normName);
            return normWithMaterial.Materials.FirstOrDefault(m => m.GuidNumber.Equals(guid));
        }

        public void RemoveNorm(string normName)
        {
            _repo.DeleteNorm(normName);
        }

        public void SaveNorm(MaterialNorm norm)
        {
            _repo.SerializeNorm(norm);
        }

        public MaterialNorm GetNorm(string normName)
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

        public List<Material> GetMaterialsFromNorm(string normName)
        {
            MaterialNorm norm = _repo.DeserializeNorm(normName);
            return norm.Materials.ToList();
        }
    }
}

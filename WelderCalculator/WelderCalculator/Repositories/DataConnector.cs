using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WelderCalculator.Drawings.SchaefflerChartView;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Repositories.Model;
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
        public AdditiveMaterial GetAdditiveMaterial(Guid guid, string normName)
        {
            var normWithMaterial = _normRepo.DeserializeAdditiveNorm(normName);
            return normWithMaterial.Materials.FirstOrDefault(m => m.GuidNumber.Equals(guid));
        }

        public void RemoveBaseNorm(string normName)
        {
            _normRepo.DeleteBaseNorm(normName);
        }
        public void RemoveAdditiveNorm(string normName)
        {
            _normRepo.DeleteAdditiveNorm(normName);
        }

        public void SaveBaseNorm(BaseNorm norm)
        {
            _normRepo.SerializeBaseNorm(norm);
        }
        public void SaveAdditiveNorm(AdditiveNorm norm)
        {
            _normRepo.SerializeAdditiveNorm(norm);
        }

        public BaseNorm GetBaseNorm(string normName)
        {
            return _normRepo.DeserializeBaseNorm(normName);
        }
        public AdditiveNorm GetAdditiveNorm(string normName)
        {
            return _normRepo.DeserializeAdditiveNorm(normName);
        }

        public List<Category.OfElement> GetOrderOfElementsForBaseMaterial()
        {
            List<Category.OfElement> order = _normRepo.DeserializeBaseNormsProperties();
            return order;
        }
        public List<Category.OfElement> GetOrderOfElementsForAdditiveMaterial()
        {
            List<Category.OfElement> order = _normRepo.DeserializeAdditiveNormsProperties();
            return order;
        }

        public void SaveBaseNormProperties(List<Category.OfElement> orderOfElements)
        {
            _normRepo.SerializeBaseNormsProperties(orderOfElements);
        }
        public void SaveAdditiveNormPRoperties(List<Category.OfElement> orderOfElements)
        {
            _normRepo.SerializeAdditiveNormsProperties(orderOfElements);
        }

        public List<string> GetNamesOfBaseNorms()
        {
            return _normRepo.GetNamesOfBaseNorms();
        }
        public List<string> GetNamesOfAdditiveNorms()
        {
            return _normRepo.GetNamesOfAdditiveNorms();
        }
       
        public List<BaseMaterial> GetBaseMaterials(string normName)
        {
            BaseNorm norm = _normRepo.DeserializeBaseNorm(normName);
            return norm.Materials.OrderBy(m => m.Name).ToList();
        }
        public List<AdditiveMaterial> GetAdditiveMaterials(string normName)
        {
            AdditiveNorm norm = _normRepo.DeserializeAdditiveNorm(normName);
            return norm.Materials.OrderBy(m => m.Name).ToList();
        }

        public List<Layer> GetSchaefflerImages()
        {
            return _normRepo.GetSchaefflerChartImages();
        }
    }
}

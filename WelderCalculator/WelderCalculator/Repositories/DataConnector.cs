using System;
using System.Collections.Generic;
using System.Linq;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories
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

        public Layers GetSchaefflerImages()
        {
            var layers = new Layers(_normRepo.GetSchaefflerChartImages());
            return layers;
        }

        public void SaveFirstBasisMarerialForSchaeffler(BaseMaterial baseMaterial)
        {
            _normRepo.SerializeFirstBaseMaterialForSchaeffler(baseMaterial);
        }

        public void SaveSecondBasisMarerialForSchaeffler(BaseMaterial baseMateiral)
        {
            _normRepo.SerializeSecondBaseMaterialForSchaeffler(baseMateiral);
        }

        public void SaveAdditionalMaterialForSchaeffler(AdditiveMaterial additionalMaterial)
        {
            _normRepo.SerializeAdditionalMaterialForSchaeffler(additionalMaterial);
        }

        public BaseMaterial GetFirstBasisMarerialForSchaeffler()
        {
            return _normRepo.DeserializeFirstBaseMaterialForSchaeffler();
        }

        public BaseMaterial GetSecondBasisMarerialForSchaeffler()
        {
            return _normRepo.DeserializeSecondBaseMaterialForSchaeffler();
        }

        public AdditiveMaterial GetAdditionalMaterialForSchaeffler()
        {
            return _normRepo.DeserializeAdditionalMaterialForSchaeffler();
        }
    }
}

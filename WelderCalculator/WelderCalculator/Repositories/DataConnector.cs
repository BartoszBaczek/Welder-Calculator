﻿using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Layers GetDeLongImages()
        {
            var layers = new Layers(_normRepo.GetDeLongChartImages());
            return layers;
        }

        public Layers GetWRC1992Images()
        {
            var layers = new Layers(_normRepo.GetWRC1992ChartImages());
            return layers;
        }

        public Layers GetSchaefflerDeLongMinimapImages()
        {
            var layers = new Layers(_normRepo.GetSchaefflerDeLongMinimapImages());
            return layers;
        }

        public Layers GetSchaefflerWRC1992MinimapImages()
        {
            var layers = new Layers(_normRepo.GetSchaefflerWRC1992MinimapImages());
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

        public ChartSizing GetSchaefflerChartSizingData()
        {
            return _normRepo.DeserializeSchaefflerChartSizing();
        }

        public ChartSizing GetDeLongChartSizingData()
        {
            return _normRepo.DeserializeDeLongChartSizing();
        }

        public ChartSizing GetWRC1992ChartSizingData()
        {
            return _normRepo.DeserializeWRC1992ChartSizing();
        }

        public ChartSizing GetSchaefflerDeLongMinimapSizingData()
        {
            return _normRepo.DeserializeSchaefflerChartSizing();
        }

        public ChartSizing GetSchaefflerWRC1992MinimapSizingData()
        {
            return _normRepo.DeserializeSchaefflerChartSizing();
        }

        public Image GetKsLogo()
        {
            return _normRepo.GetKsLogoImage();
        }

        public void SaveMainChartForPDF(Bitmap bitmap)
        {
            _normRepo.SerializeMainChartForPDF(bitmap);
        }

        public void SaveMinimapForPDF(Bitmap bitmap)
        {
            _normRepo.SerializeMinimapForPDF(bitmap);
        }

        public string PathToMainChartImage()
        {
            return _normRepo.PathToMainChartImage();
        }

        public string PathToMinimapChartImage()
        {
            return _normRepo.PathToMinimapChartImage();
        }

        public string PathToSchaefflerDiagramLegendImage()
        {
            return _normRepo.PathToSchaefflerDiagramLegendImage();
        }

        public string PathToDeLongDiagramLegendImage()
        {
            return _normRepo.PathToDeLongDiagramLegendImage();
        }

        public string PathToWrcDiagramLegendImage()
        {
            return _normRepo.PathToWrcDiagramLegendImage();
        }
    }
}

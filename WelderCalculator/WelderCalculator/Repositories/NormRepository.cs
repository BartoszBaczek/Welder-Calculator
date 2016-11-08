using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using WelderCalculator.Model;
using System.Drawing;
using WelderCalculator.Drawings.Chart;
using System.Drawing.Imaging;

namespace WelderCalculator.Repositories
{
    public class NormRepository : IBasicNormRepository, IAdditiveNormRepository, IDrawingsRepository, ISchefflerDiagramMaterials
    {
        private string _binPath;
        private readonly string _baseNormsPath;
        private readonly string _additiveNormsPath;
        private readonly string _propertiesPath;
        private readonly string _drawingsPath;
        private readonly string _pdfPath;
        private readonly string _schaefflersMaterialsRepository;

        public NormRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _baseNormsPath =                    _binPath + @"\.." + @"\Data\BaseNorms\";
            _additiveNormsPath =                _binPath + @"\.." + @"\Data\AdditiveNorms\";
            _propertiesPath =                   _binPath + @"\.." + @"\Data\Properties\";
            _drawingsPath =                     _binPath + @"\.." + @"\Data\I\";
            _pdfPath = _binPath + @"\.." + @"\Data\I\PdfImages\";
            _schaefflersMaterialsRepository = _binPath + @"\.." + @"\Data\ScheffMaterials\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public NormRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _baseNormsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\BaseNorms\";
            _additiveNormsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\AdditiveNorms\";
            _propertiesPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\Properties\";
            _drawingsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\I\";
            _pdfPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\I\PdfImages\";
            _schaefflersMaterialsRepository = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\ScheffMaterials\";
        }


        #region IBasicNormRepository && IAdditiveNormRepository
        public void SerializeBaseNorm(BaseNorm norm)
        {
            string pathToFile = _baseNormsPath + norm.Name + ".json";
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile).Dispose();
            }
            using (FileStream fs = File.Open(_baseNormsPath + norm.Name + ".json", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, norm);
            };
        }

        public void SerializeAdditiveNorm(AdditiveNorm norm)
        {
            string pathToFile = _additiveNormsPath + norm.Name + ".json";
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile).Dispose();
            }
            using (FileStream fs = File.Open(_additiveNormsPath + norm.Name + ".json", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, norm);
            };
        }

        public BaseNorm DeserializeBaseNorm(string normName)
        {
            string pathToNormFile = _baseNormsPath + normName + ".json";
            string jsonText = File.ReadAllText(pathToNormFile);
            var norm = JsonConvert.DeserializeObject<BaseNorm>(jsonText);
            return norm;
        }

        public AdditiveNorm DeserializeAdditiveNorm(string normName)
        {
            string pathToNormFile = _additiveNormsPath + normName + ".json";
            string jsonText = File.ReadAllText(pathToNormFile);
            var norm = JsonConvert.DeserializeObject<AdditiveNorm>(jsonText);
            return norm;
        }


        public void DeleteBaseNorm(string normName)
        {
            string pathToNormFile = _baseNormsPath + normName + ".json";
            File.Delete(pathToNormFile);
        }

        public void DeleteAdditiveNorm(string normName)
        {
            string pathToNormFile = _additiveNormsPath + normName + ".json";
            File.Delete(pathToNormFile);
        }

        public List<string> GetNamesOfBaseNorms()
        {
            List<string> filesNames = Directory.GetFiles(_baseNormsPath)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     .ToList();
            return filesNames;
        }

        public List<string> GetNamesOfAdditiveNorms()
        {
            List<string> filesNames = Directory.GetFiles(_additiveNormsPath)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     .ToList();
            return filesNames;
        }
        #endregion

        //TODO: Extract separate interface for those methods
        #region PropertiesSerialization (Part of IBasicNormRepository && IAdditiveNormRepository 
        public void SerializeBaseNormsProperties(List<Category.OfElement> properties)
        {
            using (var fs = File.Open(_propertiesPath + "OrderInBaseNormDataGridView.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, properties);
            }
        }

        public void SerializeAdditiveNormsProperties(List<Category.OfElement> properties)
        {
            using (var fs = File.Open(_propertiesPath + "OrderInAdditiveNormDataGridView.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, properties);
            }
        }

        public List<Category.OfElement> DeserializeBaseNormsProperties()
        {
            string fileName = "OrderInBaseNormDataGridView";
            string pathToFile = _propertiesPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var orderOfelements =
                JsonConvert.DeserializeObject<List<Category.OfElement>>(jsonText);

            return orderOfelements;
        }

        public List<Category.OfElement> DeserializeAdditiveNormsProperties()
        {
            string fileName = "OrderInAdditiveNormDataGridView";
            string pathToFile = _propertiesPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var orderOfelements =
                JsonConvert.DeserializeObject<List<Category.OfElement>>(jsonText);

            return orderOfelements;
        }
        #endregion

        #region ISchaefflerDiagramMaterials
        public void SerializeFirstBaseMaterialForSchaeffler(BaseMaterial basicMaterial)
        {
            using (var fs = File.Open(_schaefflersMaterialsRepository + "FirstMaterialForSchaeffler.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, basicMaterial);
            }
        }

        public void SerializeSecondBaseMaterialForSchaeffler(BaseMaterial basicMateiral)
        {
            using (var fs = File.Open(_schaefflersMaterialsRepository + "SecondMaterialForSchaeffler.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, basicMateiral);
            }
        }

        public void SerializeAdditionalMaterialForSchaeffler(AdditiveMaterial additionalMaterial)
        {
            using (var fs = File.Open(_schaefflersMaterialsRepository + "AdditiveMaterialForSchaeffler.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, additionalMaterial);
            }
        }

        public BaseMaterial DeserializeFirstBaseMaterialForSchaeffler()
        {
            string fileName = "FirstMaterialForSchaeffler";
            string pathToFile = _schaefflersMaterialsRepository + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var firstBaseMateiral =
                JsonConvert.DeserializeObject<BaseMaterial>(jsonText);

            return firstBaseMateiral;
        }

        public BaseMaterial DeserializeSecondBaseMaterialForSchaeffler()
        {
            string fileName = "SecondMaterialForSchaeffler";
            string pathToFile = _schaefflersMaterialsRepository + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var secondBaseMaterial =
                JsonConvert.DeserializeObject<BaseMaterial>(jsonText);

            return secondBaseMaterial;
        }

        public AdditiveMaterial DeserializeAdditionalMaterialForSchaeffler()
        {
                string fileName = "AdditiveMaterialForSchaeffler";
                string pathToFile = _schaefflersMaterialsRepository + fileName + ".json";
                string jsonText = File.ReadAllText(pathToFile);

                var additiveMaterial =
                    JsonConvert.DeserializeObject<AdditiveMaterial>(jsonText);

                return additiveMaterial;
        }
        #endregion

        #region IDrawingsRepository

        public List<Layer> GetSchaefflerChartImages()
        {
            string schaeflerCatalog = "Schaeffler/";
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_background.png"), SchaefflerLayerType.Background),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_cracking.png"), SchaefflerLayerType.Cracking),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_x.png"), SchaefflerLayerType.AxisX),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_y.png"), SchaefflerLayerType.AxisY),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_hash.png"), SchaefflerLayerType.Hash),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_phase.png"), SchaefflerLayerType.Phase),
                new Layer(Image.FromFile(_drawingsPath + schaeflerCatalog + "s_haseText.png"), SchaefflerLayerType.PhaseText)
            };

            return layers;
        }

        public ChartSizing DeserializeSchaefflerChartSizing()
        {
            string fileName = "Schaeffler/chartSizing";

            string pathToFile = _drawingsPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var chartSizing =
                JsonConvert.DeserializeObject<ChartSizing>(jsonText);

            return chartSizing;
        }

        public List<Layer> GetDeLongChartImages()
        {
            string deLongCatalog = "DeLong/";
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_background.png"), DeLongLayerType.Background),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_x.png"), DeLongLayerType.AxisX),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_y.png"), DeLongLayerType.AxisY),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_recomendedFerriteQuantity.png"), DeLongLayerType.ReccomendedFerriteContent),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_phase.png"), DeLongLayerType.Phase),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_hash.png"), DeLongLayerType.Hash),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_phaseText.png"), DeLongLayerType.PhaseText),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_ferriteNumber.png"), DeLongLayerType.FerriteNumber),
                new Layer(Image.FromFile(_drawingsPath + deLongCatalog + "d_ferriteContent.png"), DeLongLayerType.FerriteContent)
            };

            return layers;
        }

        public List<Layer> GetSchaefflerDeLongMinimapImages()
        {
            string schaefflerDeLongCatalog = "SchaefflerDeLongMinimap/";
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + schaefflerDeLongCatalog + "sdl_all.png"), SchaefflerDeLongMinimapLayerType.Only)
            };

            return layers;
        }

        public List<Layer> GetSchaefflerWRC1992MinimapImages()
        {
            string schaefflerWRC1992Catalog = "SchaefflerWRC1992Minimap/";
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + schaefflerWRC1992Catalog + "swrc_all.png"), SchaefflerWRC1992MinimapLayerType.Only)
            };

            return layers;
        }

        public ChartSizing DeserializeDeLongChartSizing()
        {
            string fileName = "DeLong/chartSizing";

            string pathToFile = _drawingsPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var chartSizing =
                JsonConvert.DeserializeObject<ChartSizing>(jsonText);

            return chartSizing;
        }

        public List<Layer> GetWRC1992ChartImages()
        {
            string wrcCatalog = "WRC1992/";
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + wrcCatalog + "wrc_background.png"), WRC1992LayerType.Background),
                new Layer(Image.FromFile(_drawingsPath + wrcCatalog + "wrc_phases.png"), WRC1992LayerType.Phase),
                new Layer(Image.FromFile(_drawingsPath + wrcCatalog + "wrc_axis.png"), WRC1992LayerType.Axis),
                new Layer(Image.FromFile(_drawingsPath + wrcCatalog + "wrc_hash.png"), WRC1992LayerType.Hash),
                new Layer(Image.FromFile(_drawingsPath + wrcCatalog + "wrc_FN.png"), WRC1992LayerType.FnContent),
            };

            return layers;
        }

        public ChartSizing DeserializeWRC1992ChartSizing()
        {
            string fileName = "WRC1992/chartSizing";

            string pathToFile = _drawingsPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var chartSizing =
                JsonConvert.DeserializeObject<ChartSizing>(jsonText);

            return chartSizing;
        }

        public Image GetKsLogoImage()
        {
            return Image.FromFile(_drawingsPath + "ks.png");
        }

        #endregion

        public void SerializeMainChartForPDF(Bitmap bitmap)
        {
            string chartImageCatalog = "PdfImages/";

            string pathToFile = _drawingsPath + chartImageCatalog + "mainChart.png";
            bitmap.Save(pathToFile, ImageFormat.Png);
        }

        public void SerializeMinimapForPDF(Bitmap bitmap)
        {
            string chartImageCatalog = "PdfImages/";

            string pathToFile = _drawingsPath + chartImageCatalog + "miniMap.png";
            bitmap.Save(pathToFile, ImageFormat.Png);
        }

        public string PathToMainChartImage()
        {
            return _pdfPath + "mainChart.png";
        }

        public string PathToMinimapChartImage()
        {
            return _pdfPath + "miniMap.png";
        }

        public string PathToSchaefflerDiagramLegendImage()
        {
            return _pdfPath + "schaefflerLegend.png";
        }

        public string PathToDeLongDiagramLegendImage()
        {
            return _pdfPath + "deLongLegend.png";
        }

        public string PathToWrcDiagramLegendImage()
        {
            return _pdfPath + "wrcLegend.png";
        }
    }
}

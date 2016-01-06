using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using WelderCalculator.Drawings.SchaefflerChartView;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model;
using WelderCalculator.Repositories.Model.temp2;
using System.Drawing;

namespace WelderCalculator.Repositories
{
    public class NormRepository : IBasicNormRepository, IAdditiveNormRepository, IDrawingsRepository
    {

        private string _binPath;
        private readonly string _baseNormsPath;
        private readonly string _additiveNormsPath;
        private readonly string _propertiesPath;
        private readonly string _drawingsPath;

        public NormRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _baseNormsPath =     _binPath + @"\.." + @"\Data\BaseNorms\";
            _additiveNormsPath = _binPath + @"\.." + @"\Data\AdditiveNorms\";
            _propertiesPath =    _binPath + @"\.." + @"\Data\Properties\";
            _drawingsPath =      _binPath + @"\.." + @"\Data\I\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public NormRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _baseNormsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\BaseNorms\";
            _additiveNormsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\AdditiveNorms\";
            _propertiesPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\Properties\";
            _drawingsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\wCalc\wCalc\WelderCalculator\WelderCalculator\Data\I\";
        }


        #region NormsSerialization
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


        #region PropertiesSerialization
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


        public List<Layer> GetSchaefflerChartImages()
        {
            var layers = new List<Layer>()
            {
                new Layer(Image.FromFile(_drawingsPath + "s_background.png"), LayerType.Background),
                new Layer(Image.FromFile(_drawingsPath + "s_x.png"), LayerType.AxisX),
                new Layer(Image.FromFile(_drawingsPath + "s_y.png"), LayerType.AxisY),
                new Layer(Image.FromFile(_drawingsPath + "s_hash.png"), LayerType.Hash),
                new Layer(Image.FromFile(_drawingsPath + "s_phase.png"), LayerType.Phase),
            };

            return layers;
        } 
    }
}

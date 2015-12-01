using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories
{
    public class BasicMaterialRepository : IBasicMaterialRepository
    {

        private string _binPath;
        private string _normsPath;
        private string _propertiesPath;

        public BasicMaterialRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _normsPath = _binPath + @"\.." + @"\Data\";
            _propertiesPath = _binPath + @"\.." + @"\Data\Properties\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public BasicMaterialRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _normsPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\";
            _propertiesPath = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\Properties\";
        }


        #region NormsSerialization
        public void SerializeNorm(MaterialNorm norm)
        {
            string pathToFile = _normsPath + norm.Name + ".json";
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile).Dispose();
            }
            using (FileStream fs = File.Open(_normsPath + norm.Name + ".json", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, norm);
            };
        }

        public MaterialNorm DeserializeNorm(string normName)
        {
            string pathToNormFile = _normsPath + normName + ".json";
            string jsonText = File.ReadAllText(pathToNormFile);
            var norm = JsonConvert.DeserializeObject<MaterialNorm>(jsonText);
            return norm;
        }

        public void DeleteNorm(string normName)
        {
            string pathToNormFile = _normsPath + normName + ".json";
            File.Delete(pathToNormFile);
        }

        public List<string> GetNamesOfNorms()
        {
            List<string> filesNames = Directory.GetFiles(_normsPath)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     .ToList();
            return filesNames;
        } 
        #endregion




        #region PropertiesSerialization
        public void SerializeProperties(List<Category.OfElement> properties)
        {
            using (var fs = File.Open(_normsPath + "OrderInDataGridView.json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, properties);
            }
        }

        public List<Category.OfElement> DeserializeProperties()
        {
            string fileName = "OrderInDataGridView";
            string pathToFile = _propertiesPath + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var orderOfelements =
                JsonConvert.DeserializeObject<List<Category.OfElement>>(jsonText);

            return orderOfelements;
        } 
        #endregion
    }
}

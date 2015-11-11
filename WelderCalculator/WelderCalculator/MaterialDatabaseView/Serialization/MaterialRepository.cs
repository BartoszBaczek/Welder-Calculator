using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using WelderCalculator.Model;

namespace WelderCalculator.Serialization
{
    public class MaterialRepository : IMaterialRepository
    {
        private string _binPath;
        private readonly string _dataFolder;
        private readonly string _optionsDataFolder;

        public MaterialRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _dataFolder = _binPath + @"\.." + @"\Data\";
            _optionsDataFolder = _binPath + @"\.." + @"\Data\Properties\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public MaterialRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _dataFolder = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\";
            _optionsDataFolder = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\Properties\";
        }
        
        public void SaveToFile(MaterialNorm norm)
        {
            using (FileStream fs = File.Open(_dataFolder + norm.Name + ".json", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, norm);
            }
        }
        
        public string[] GetNamesOfFilesInDataFolder()
        {
            string[] filesNames = Directory.GetFiles(_dataFolder)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     .ToArray();
            return filesNames;
        }

        public MaterialNorm GetNorm(string normName)
        {
            string pathToNormFile = _dataFolder + normName + ".json";
            string jsonText = File.ReadAllText(pathToNormFile);
            var norm = JsonConvert.DeserializeObject<MaterialNorm>(jsonText);
            return norm;
        }

        public List<Category.OfElement> GetOrderOfElements()
        {
            string fileName = "OrderInDataGridView";
            string pathToFile = _optionsDataFolder + fileName + ".json";
            string jsonText = File.ReadAllText(pathToFile);

            var orderOfelements =
                JsonConvert.DeserializeObject<List<Category.OfElement>>(jsonText);

            return orderOfelements;
        }
    }
}
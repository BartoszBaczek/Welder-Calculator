using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using WelderCalculator.Model;

namespace WelderCalculator.Serialization
{
    public class Repository : IRepository
    {
        private string _binPath;
        private readonly string _dataFolder;

        public Repository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _dataFolder = _binPath + @"\.." + @"\Data\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public Repository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _dataFolder = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\";

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
            MaterialNorm norm = JsonConvert.DeserializeObject<MaterialNorm>(File.ReadAllText(pathToNormFile));

            return norm;
        }
    }
}
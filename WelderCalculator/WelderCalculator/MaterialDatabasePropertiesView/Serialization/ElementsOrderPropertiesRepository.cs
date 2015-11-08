using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace WelderCalculator.MaterialDatabasePropertiesView.Serialization
{
    public class ElementsOrderPropertiesRepository : IElementsOrderPropertiesRepository
    {
        private string _binPath;
        private readonly string _dataFolder;
        private string _fileName;

        public ElementsOrderPropertiesRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _dataFolder = _binPath + @"\.." + @"\Data\Properties\";
            _fileName = "OrderInDataGridView";
        }

        /*Use this constructor ONLY for testing!!!*/
        public ElementsOrderPropertiesRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _dataFolder = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\Properties\";
            _fileName = "OrderInDataGridView";
        }

        public void SaveToFile(List<Model.Category.OfElement> norm)
        {
            using (var fs = File.Open(_dataFolder + _fileName + ".json", FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, norm);
            }
        }
    }
}

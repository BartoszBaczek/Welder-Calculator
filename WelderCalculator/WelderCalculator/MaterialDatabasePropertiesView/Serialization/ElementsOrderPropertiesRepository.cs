using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace WelderCalculator.MaterialDatabasePropertiesView.Serialization
{
    public class ElementsOrderPropertiesRepository : IElementsOrderPropertiesRepository
    {
        private string _binPath;
        private readonly string _dataFolder;

        public ElementsOrderPropertiesRepository()
        {
            _binPath = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            _dataFolder = _binPath + @"\.." + @"\Data\Properties\";
        }

        /*Use this constructor ONLY for testing!!!*/
        public ElementsOrderPropertiesRepository(string filePathForTestsOnly)
        {
            _binPath = string.Empty;
            _dataFolder = @"C:\Users\Bartek\Documents\Moje dokumenty\Project\Welder-Calculator\Welder-Calculator\WelderCalculator\WelderCalculator\Data\Properties\";
        }

        public void SaveToFile(List<Model.Category.OfElement> norm)
        {
            throw new NotImplementedException();
        }
    }
}

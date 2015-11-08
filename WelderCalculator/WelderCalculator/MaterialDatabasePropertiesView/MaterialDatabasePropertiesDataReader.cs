using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesDataReader
    {
        private readonly IElementsOrderPropertiesRepository _repository;

        public MaterialDatabasePropertiesDataReader()
        {
            _repository = new ElementsOrderPropertiesRepository();
        }

        /*Use this constructor ONLY for testing!!!*/
        public MaterialDatabasePropertiesDataReader(string filePathForTestsOnly)
        {
            _repository = new ElementsOrderPropertiesRepository(filePathForTestsOnly);
        }

        public void SaveOrderOfElementsToFile(List<string> elementsInOrder)
        {
            var elementsToSave = (from elementName in elementsInOrder 
                                  where !string.IsNullOrEmpty(elementName) 
                                  select (Category.OfElement) Enum.Parse(typeof (Category.OfElement), elementName))
                                  .ToList();

            _repository.SaveToFile(elementsToSave);
        }

        public List<string> GetOrderOfElementFromFile()
        {
            var orderOfElementsFromFile = _repository.GetFromFile();
            var orderOfElements = new List<string>();

            foreach (var element in orderOfElementsFromFile)
            {
                orderOfElements.Add(element.ToString());
            }

            return orderOfElements;
        }
    }
}

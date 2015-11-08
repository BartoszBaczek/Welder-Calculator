using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView.Serialization
{
    public interface IElementsOrderPropertiesRepository
    {
        void SaveToFile(List<Category.OfElement> norm);
        List<Category.OfElement> GetFromFile();
    }
}

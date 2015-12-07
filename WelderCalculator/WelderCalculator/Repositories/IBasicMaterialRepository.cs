using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp2;

namespace WelderCalculator.Repositories
{
    public interface IBasicMaterialRepository
    {
        void SerializeNorm(BaseNorm norm);
        BaseNorm DeserializeNorm(string normName);
        void DeleteNorm(string normName);
        List<string> GetNamesOfNorms();


        void SerializeProperties(List<Category.OfElement> properties);
        List<Category.OfElement> DeserializeProperties();
    }
}

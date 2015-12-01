using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories
{
    public interface IBasicMaterialRepository
    {
        void SerializeNorm(MaterialNorm norm);
        MaterialNorm DeserializeNorm(string normName);
        void DeleteNorm(string normName);
        List<string> GetNamesOfNorms();


        void SerializeProperties(List<Category.OfElement> properties);
        List<Category.OfElement> DeserializeProperties();
    }
}

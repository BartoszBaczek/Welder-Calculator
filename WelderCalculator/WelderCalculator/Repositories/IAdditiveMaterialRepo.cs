using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model;

namespace WelderCalculator.Repositories
{
    public interface IAdditiveMaterialRepo
    {
        void SerializeNorm(AdditiveNorm norm);
        AdditiveNorm DeserializeNorm(string normName);
        void DeleteNorm(string normName);
        List<string> GetNamesOfNorms();


        void SerializeProperties(List<Category.OfElement> properties);
        List<Category.OfElement> DeserializeProperties();
    }
}

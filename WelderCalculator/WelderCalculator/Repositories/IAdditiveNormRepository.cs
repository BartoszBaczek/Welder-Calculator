using System.Collections.Generic;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model;

namespace WelderCalculator.Repositories
{
    public interface IAdditiveNormRepository
    {
        void SerializeAdditiveNorm(AdditiveNorm norm);
        AdditiveNorm DeserializeAdditiveNorm(string normName);
        void DeleteAdditiveNorm(string normName);
        List<string> GetNamesOfAdditiveNorms();


        void SerializeAdditiveNormsProperties(List<Category.OfElement> properties);
        List<Category.OfElement> DeserialzieAdditiveNormsProperties();
    }
}

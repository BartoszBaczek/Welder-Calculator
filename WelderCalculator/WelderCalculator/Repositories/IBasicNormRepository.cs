using System.Collections.Generic;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp2;

namespace WelderCalculator.Repositories
{
    public interface IBasicNormRepository
    {
        void SerializeBaseNorm(BaseNorm norm);
        BaseNorm DeserializeBaseNorm(string normName);
        void DeleteBaseNorm(string normName);
        List<string> GetNamesOfBaseNorms();

        void SerializeBaseNormsProperties(List<Category.OfElement> properties);
        List<Category.OfElement> DeserializeBaseNormsProperties();
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WelderCalculator.Model;

namespace WelderCalculator.Serialization
{
    public interface IMaterialRepository
    {
        void SaveToFile(MaterialNorm norm);

        string[] GetNamesOfFilesInDataFolder();

        MaterialNorm GetNorm(string normName);

        List<Category.OfElement> GetOrderOfElements();

        Material GetMaterialByGUID(Guid guidToFind, string materialNormName);
    }
}

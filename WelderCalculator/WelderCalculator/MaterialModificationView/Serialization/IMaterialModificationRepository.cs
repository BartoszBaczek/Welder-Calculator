using System;
using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialModificationView.Serialization
{
    interface IMaterialModificationRepository
    {
        void SaveToFile(MaterialNorm norm);

        string[] GetNamesOfFilesInDataFolder();

        MaterialNorm GetNorm(string normName);

        List<Category.OfElement> GetOrderOfElements();

        Material GetMaterialByGUID(Guid guidToFind, string materialNormName);

        void DeleteNormFile(string normName);
    }
}

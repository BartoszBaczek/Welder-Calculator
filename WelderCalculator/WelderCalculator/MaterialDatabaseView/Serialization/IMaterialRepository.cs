using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.Serialization
{
    public interface IMaterialRepository
    {
        void SaveToFile(MaterialNorm norm);

        string[] GetNamesOfFilesInDataFolder();

        MaterialNorm GetNorm(string normName);
    }
}

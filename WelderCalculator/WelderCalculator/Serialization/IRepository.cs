using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.Serialization
{
    public interface IRepository
    {
        void SaveToFile(MaterialNorm norm);

        string[] GetNamesOfFilesInDataFolder();

        MaterialNorm GetNorm(string normName);
    }
}

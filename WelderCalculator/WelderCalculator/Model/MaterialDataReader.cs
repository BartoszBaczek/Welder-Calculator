﻿
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WelderCalculator.Serialization;

namespace WelderCalculator.Model
{
    public class MaterialDataReader
    {
        private readonly IMaterialRepository _repository;

        public MaterialDataReader()
        {
            _repository = new MaterialRepository();
        }

        /*Use this constructor ONLY for testing!!!*/
        public MaterialDataReader(string filePathForTestsOnly)
        {
            _repository = new MaterialRepository(filePathForTestsOnly);
        }

        public List<string> GetSortedListOfMaterialsNormsNames()
        {
            string[] filesNames = _repository.GetNamesOfFilesInDataFolder();
            List<string> sortedListOfFiles = filesNames.OrderBy(q => q).ToList();

            return sortedListOfFiles;
        }

        public List<Material> GetListOfMaterialsFromNorm(string normName)
        {
            MaterialNorm norm = _repository.GetNorm(normName);

            List<Material> sortedListOfMaterials = norm.Materials.OrderBy(q => q.Name).ToList();

            return sortedListOfMaterials;
        }
    }
}

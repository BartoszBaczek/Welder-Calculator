using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Repositories.Model;

namespace WelderCalculator.Repositories
{
    public interface ISchefflerDiagramMaterials
    {
        void SerializeFirstBaseMaterialForSchaeffler(BaseMaterial basicMaterial);
        void SerializeSecondBaseMaterialForSchaeffler(BaseMaterial basicMateiral);
        void SerializeAdditionalMaterialForSchaeffler(AdditiveMaterial additionalMaterial);

        BaseMaterial DeserializeFirstBaseMaterialForSchaeffler();
        BaseMaterial DeserializeSecondBaseMaterialForSchaeffler();
        AdditiveMaterial DeserializeAdditionalMaterialForSchaeffler();
    }
}

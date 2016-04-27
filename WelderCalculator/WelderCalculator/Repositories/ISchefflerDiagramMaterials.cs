using WelderCalculator.Model;

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

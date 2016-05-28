
namespace WelderCalculator.Views.FastMaterialFactoryView
{
    public interface IFastMaterialFactoryView
    {
        FastMaterialFactoryPresenter Presenter { set; }
        //baseMaterial1
        double? NiBaseMaterial1 { get; set; }
        double? CrBaseMaterial1 { get; set; }
        double? CBaseMaterial1 { get; set; }
        double? MnBaseMaterial1 { get; set; }
        double? MoBaseMaterial1 { get; set; }
        double? NBaseMaterial1 { get; set; }
        double? SiBaseMaterial1 { get; set; }
        double? NbBaseMaterial1 { get; set; }
        double? TiBaseMaterial1 { get; set; }
        bool ChangeBaseMaterial1Checked { get; set; }

        //baseMaterial2
        double? NiBaseMaterial2 { get; set; }
        double? CrBaseMaterial2 { get; set; }
        double? CBaseMaterial2 { get; set; }
        double? MnBaseMaterial2 { get; set; }
        double? MoBaseMaterial2 { get; set; }
        double? NBaseMaterial2 { get; set; }
        double? SiBaseMaterial2 { get; set; }
        double? NbBaseMaterial2 { get; set; }
        double? TiBaseMaterial2 { get; set; }
        bool ChangeBaseMaterial2Checked { get; set; }

        //baseMaterial2
        double? NiAddMaterial { get; set; }
        double? CrAddMaterial { get; set; }
        double? CAddMaterial { get; set; }
        double? MnAddMaterial { get; set; }
        double? MoAddMaterial { get; set; }
        double? NAddMaterial { get; set; }
        double? SiAddMaterial { get; set; }
        double? NbAddMaterial { get; set; }
        double? TiAddMaterial { get; set; }
        bool ChangeAdditionalMaterialChecked { get; set; }
    }
}

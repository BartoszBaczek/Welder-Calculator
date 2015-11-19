
namespace WelderCalculator.MaterialModificationView
{
    public interface IMaterialModificationView
    {
        MaterialModificationPresenter Presenter { set; }

        string NameTextbox { get; set; }
        string NumberTextbox { get; set; }
        string GuidTextbox { get; set; }

        double? Ctextbox { get; set; }
        double? Sitextbox { get; set; }
        double? Mntextbox { get; set; }
        double? Ptextbox { get; set; }
        double? Stextbox { get; set; }
        double? Ntextbox { get; set; }
        double? Crtextbox { get; set; }
        double? Motextbox { get; set; }
        double? Nbtextbox { get; set; }
        double? Nitextbox { get; set; }
        double? Titextbox { get; set; }
        double? Altextbox { get; set; }
        double? Vtextbox { get; set; }
        double? Cutextbox { get; set; }
    }
}

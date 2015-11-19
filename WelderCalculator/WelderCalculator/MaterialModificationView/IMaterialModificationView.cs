
namespace WelderCalculator.MaterialModificationView
{
    public interface IMaterialModificationView
    {
        MaterialModificationPresenter Presenter { set; }

        string NameTextbox { get; set; }
        string NumberTextbox { get; set; }
        string GuidTextbox { get; set; }

        double?  CMintextbox { get; set; }
        double? SiMintextbox { get; set; }
        double? MnMintextbox { get; set; }
        double?  PMintextbox { get; set; }
        double?  SMintextbox { get; set; }
        double?  NMintextbox { get; set; }
        double? CrMintextbox { get; set; }
        double? MoMintextbox { get; set; }
        double? NbMintextbox { get; set; }
        double? NiMintextbox { get; set; }
        double? TiMintextbox { get; set; }
        double? AlMintextbox { get; set; }
        double?  VMintextbox { get; set; }
        double? CuMintextbox { get; set; }

        double?  CMaxtextbox { get; set; }
        double? SiMaxtextbox { get; set; }
        double? MnMaxtextbox { get; set; }
        double?  PMaxtextbox { get; set; }
        double?  SMaxtextbox { get; set; }
        double?  NMaxtextbox { get; set; }
        double? CrMaxtextbox { get; set; }
        double? MoMaxtextbox { get; set; }
        double? NbMaxtextbox { get; set; }
        double? NiMaxtextbox { get; set; }
        double? TiMaxtextbox { get; set; }
        double? AlMaxtextbox { get; set; }
        double?  VMaxtextbox { get; set; }
        double? CuMaxtextbox { get; set; }

        double?  CRealtextbox { get; set; }
        double? SiRealtextbox { get; set; }
        double? MnRealtextbox { get; set; }
        double?  PRealtextbox { get; set; }
        double?  SRealtextbox { get; set; }
        double?  NRealtextbox { get; set; }
        double? CrRealtextbox { get; set; }
        double? MoRealtextbox { get; set; }
        double? NbRealtextbox { get; set; }
        double? NiRealtextbox { get; set; }
        double? TiRealtextbox { get; set; }
        double? AlRealtextbox { get; set; }
        double?  VRealtextbox { get; set; }
        double? CuRealtextbox { get; set; }
    }
}

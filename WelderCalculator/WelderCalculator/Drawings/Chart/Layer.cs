using System.Drawing;

namespace WelderCalculator.Drawings.Chart
{
    public class SchaefflerLayerType
    {
        public static readonly string Background = "schaefflerBackground";
        public static readonly string AxisX = "schaefflerAxisX";
        public static readonly string AxisY = "schaefflerAxisY";
        public static readonly string Hash = "schaefflerHash";
        public static readonly string Phase = "schaefflerPhase";
        public static readonly string PhaseText = "schaefflerPhaseText";
        public static readonly string Cracking = "schaefflerCracking";
    }

    public class DeLongLayerType
    {
        public static readonly string Background = "deLongBackground";
        public static readonly string AxisX = "deLongAxisX";
        public static readonly string AxisY = "deLongAxisY";
        public static readonly string Hash = "deLongHash";
        public static readonly string Phase = "deLongPhase";
        public static readonly string PhaseText = "deLongPhaseText";
        public static readonly string FerriteContent = "deLongFerriteContent";
        public static readonly string FerriteNumber = "deLongFerriteNumber";
        public static readonly string ReccomendedFerriteContent = "deLongReccomendedFerriteContent";
    }

    public class WRC1992LayerType
    {
        public static readonly string Background = "wrcBackground";
        public static readonly string Axis = "wrcAxis";
        public static readonly string Hash = "wrcHash";
        public static readonly string Phase = "wrcPhase";
        public static readonly string FnContent = "wrcFnContent";
    }

    public class SchaefflerDeLongMinimapLayerType
    {
        public static readonly string Only = "schaefflerDeLongOnly";
    }

    public class SchaefflerWRC1992MinimapLayerType
    {
        public static readonly string Only = "schaefflerWRC1992Only";
    }

    public class Layer
    {
        public Image Image;
        public string Type;

        public Layer(Image image, string layerType)
        {
            Image = image;
            Type = layerType;
        }
    }
}

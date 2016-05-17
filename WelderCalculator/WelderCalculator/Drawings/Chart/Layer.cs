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

using System.Drawing;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public enum LayerType
    {
        Background,
        AxisX,
        AxisY,
        Hash,
        Phase
    }

    public class Layer
    {
        public Image Image;
        public LayerType Type;

        public Layer(Image image, LayerType type)
        {
            Image = image;
            Type = type;
        }
    }
}

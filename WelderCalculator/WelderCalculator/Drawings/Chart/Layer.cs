using System.Drawing;

namespace WelderCalculator.Drawings.Chart
{
    public enum LayerType
    {
        Background,
        AxisX,
        AxisY,
        Hash,
        Phase,
        PhaseText
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

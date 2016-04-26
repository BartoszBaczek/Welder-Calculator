using System.Drawing;

namespace WelderCalculator.Drawings.Chart
{
    public interface IChart
    {
        Layers Layers { get; }
       //  void ResizeTo(int width, int height);
        void AddPoint(PointF point, Color color);
        void AddLine(PointF point1, PointF point2, Color color);
        void Draw();
        void Clean();
    }
}

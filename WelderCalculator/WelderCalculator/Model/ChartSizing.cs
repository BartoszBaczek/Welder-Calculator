using System.Drawing;

namespace WelderCalculator.Model
{
    public class ChartSizing
    {

        /*
         ________________________________(1)
         |Diagram with surroundings here |
         |  _____________________(3), (4)|
         | |                           | |
         | |     Only diagram here     | |
         | |                           | |
         | |(2, 5)_____________________| |
         |_______________________________|
         
         
         */
        // size of whole image in px (1)
        public PointF ImageWidthAndHeight { get; set; }

        // position of diagram origin in px (2)
        public PointF ChartOriginXandY { get; set; }

        // end point of diagram in px (3)
        public PointF ChartEndPointXandY { get; set; }

        // end point of diagram in diagram unit (4)
        public PointF ChartEndInSpecialUnit { get; set; }

        // position of diagram origin in diagram unit (5)
        public PointF ChartOriginInSpecialUnit { get; set; }
    }
}

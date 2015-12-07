using System.Drawing;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form
    {
        private Graphics _graphics;

        public SchaefflerChartForm()
        {
            InitializeComponent();
            DrawImage();
        }

        private void DrawImage()
        {
            using (Graphics g = this.panel1.CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 2);
                Brush brush = new SolidBrush(this.panel1.BackColor);

                g.DrawRectangle(pen, 100, 100, 100, 200);

                pen.Dispose();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);
            Point[] points = new Point[5];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, p.Height);
            points[2] = new Point(p.Width, p.Height);
            points[3] = new Point(p.Width, 0);
            points[4] = new Point(50, 50);

            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            Point[] points_2 = new Point[3];

            points_2[0] = new Point(50, 50);
            points_2[1] = new Point(150, 150);
            points_2[2] = new Point(223, 534);

            brush = new SolidBrush(Color.Brown);
            Rectangle rect = new Rectangle(0, 0, 300, 300);
            g.FillPie(brush, rect, 34, 78);
        }

    }
}

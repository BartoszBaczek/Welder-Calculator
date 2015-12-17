using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form, ISchaefflerChartView
    {
        public SchaefflerChartPresenter Presenter { private get; set; }

        public SchaefflerChartForm()
        {
            InitializeComponent();
            new SchaefflerChartPresenter(this);
            EnableResizeRedraw();
        }

        private void EnableResizeRedraw()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Presenter.Draw(e);
        }

        private void SchaefflerChartForm_Load(object sender, System.EventArgs e)
        {

        }


        
    }
}

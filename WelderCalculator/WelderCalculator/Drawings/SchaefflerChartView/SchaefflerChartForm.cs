using System;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form, ISchaefflerChartView
    {
        public SchaefflerChartPresenter Presenter { private get; set; }

        public int CanvasWidth { get { return panel1.Width; } }

        public int CanvasHeight { get { return panel1.Height; } }

        public SchaefflerChartForm()
        {
            InitializeComponent();
            new SchaefflerChartPresenter(this);
            EnableResizeRedraw();
            
        }

        private void EnableResizeRedraw()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Presenter.Draw(e);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.Refresh();
            ResumeLayout();
            base.OnResizeEnd(e);
        }
    }
}

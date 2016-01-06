using System;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form, ISchaefflerChartView
    {
        public SchaefflerChartPresenter Presenter { private get; set; }

        public int DrawPanelWidth { get { return drawPanel.Width; } }

        public int DrawPanelHeight { get { return drawPanel.Height; } }

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

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            Presenter.Draw(drawPanel.Handle, e);
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
            drawPanel.Refresh();
        }
    }
}

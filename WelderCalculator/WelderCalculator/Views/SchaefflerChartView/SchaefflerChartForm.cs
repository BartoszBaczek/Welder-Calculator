using System;
using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form, ISchaefflerChartView
    {
        public SchaefflerChartPresenter Presenter { private get; set; }

        public int DrawPanelWidth { get { return drawPanel.Width; } }

        public int DrawPanelHeight { get { return drawPanel.Height; } }

        public IntPtr DrawPanelCanvas { get { return drawPanel.Handle; } }

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
            Presenter.OnPaintEvent(drawPanel.Handle, e);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
            drawPanel.Refresh();
        }

        #region Visibility checkboxes
        public bool BackgroundVisibleCheckBox
        {
            get { return backgroundCheckBox.Checked; }
            set { backgroundCheckBox.Checked = value; } 
        }

        public bool HashVisibleCheckBox
        {
            get { return hashCheckBox.Checked; }
            set { hashCheckBox.Checked = value; } 
        }

        public bool XAxisVisibleCheckBox
        {
            get { return xAxisCheckBox.Checked; }
            set { xAxisCheckBox.Checked = value; } 
        }

        public bool YAxisVisibleCheckBox
        {
            get { return yAxisCheckBox.Checked; }
            set { yAxisCheckBox.Checked = value; } 
        }

        public bool PhaseLinesVisibleCheckBox
        {
            get { return phaseCheckBox.Checked; }
            set { phaseCheckBox.Checked = value; } 
        }

        private void backgroundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(LayerType.Background, BackgroundVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void hashCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(LayerType.Hash, HashVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void xAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(LayerType.AxisX, XAxisVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void yAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(LayerType.AxisY, YAxisVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void phaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(LayerType.Phase, PhaseLinesVisibleCheckBox);
            drawPanel.Refresh();
        }
        #endregion


        #region Controls setting parameters
        public string FirstBaseMaterialTextBox
        {
            get { return firstBaseMaterialTextBox.Text; }
            set { firstBaseMaterialTextBox.Text = value; }
        }

        public string SecondBaseMaterialTextBox
        {
            get { return secondBaseMaterialTextBox.Text; }
            set { secondBaseMaterialTextBox.Text = value; }
        }

        public string AdditionalMaterialTextBox
        {
            get { return additionalMaterialTextBox.Text; }
            set { additionalMaterialTextBox.Text = value; }
        }

        public string AdditionalMaterialQuantity
        {
            get { return additionalMaterialQuantityTextBox.Text; }
            set { additionalMaterialQuantityTextBox.Text = value; }
        } 
        #endregion

        private void firstBaseMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnFirstBaseMaterialButtonClicked();
        }

        private void secondBaseMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnSecondBaseMaterialButtonClicked();
        }

        private void addititionalMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnAdditionalMaterialButtonClicked();
        }

        private void countButton_Click(object sender, EventArgs e)
        {
        }
    }
}

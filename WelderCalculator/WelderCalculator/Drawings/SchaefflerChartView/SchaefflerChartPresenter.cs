using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.MaterialModificationView.Serialization;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;
        private readonly DataConnector _dataConnector;
        private readonly Chart _chart;

        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view; 
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _chart = new Chart(_dataConnector.GetSchaefflerImages());

            SetVisibilityCheckBoxesToTrue();
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.Resize(_view.DrawPanelWidth, _view.DrawPanelHeight);

            Graphics graphics = Graphics.FromHwnd(_view.DrawPanelCanvas);
            _chart.Draw(graphics);
        }

        public void OnLayerVisibilityChanged(LayerType type, bool visibility)
        {
            if (!visibility)
                _chart.Layers.Remove(type);
            else
                _chart.Layers.Add(type);
        }

        private void SetVisibilityCheckBoxesToTrue()
        {
            _view.BackgroundVisibleCheckBox = true;
            _view.HashVisibleCheckBox = true;
            _view.XAxisVisibleCheckBox = true;
            _view.YAxisVisibleCheckBox = true;
            _view.PhaseLinesVisibleCheckBox = true;
        }
    }
}

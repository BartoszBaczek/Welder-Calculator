using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.Repositories;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Helpers;
namespace WelderCalculator.Views.SchaefflerMinimapView
{
    public class SchaefflerMinimapPresenter
    {
        private readonly ISchaefflerMinimapView _view;
        private readonly DataConnector _dataConnector;
        private IChart _chart;

        private double _additionalMaterialQuantity;

        public SchaefflerMinimapPresenter(ISchaefflerMinimapView view, MinimapCombination minimapCombination, double additionalMaterialQuantity)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _additionalMaterialQuantity = additionalMaterialQuantity;

            LoadChartData(minimapCombination);
            DrawLines();
        }

        private void LoadChartData(MinimapCombination minimapCombination)
        {
            if (minimapCombination == MinimapCombination.SchaefflerDeLong)
            {
                _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                    _dataConnector.GetSchaefflerDeLongMinimapImages(),
                    _dataConnector.GetSchaefflerDeLongMinimapSizingData());
            }
            else if (minimapCombination == MinimapCombination.SchaefflerWRC1992)
            {
                //_chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                //    _dataConnector.GetSchaefflerWRC1992MinimapImages(),
                //    _dataConnector.GetSchaefflerWRC1992MinimapSizingData());
            }
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
        }

        public void OnOKButtonClicked()
        {
            _view.CancelDialog();
        }

        private void DrawLines()
        {
            double? additionalMaterialQuantity = _additionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if (!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100");
                return;
            }

            var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            PointF pointForFirstMaterial = new PointF((float)firstMaterial.CrEq, (float)firstMaterial.NiEq);

            var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            PointF pointForSecondMaterial = new PointF((float)secondMaterial.CrEq, (float)secondMaterial.NiEq);

            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            PointF pointForAddMaterial = new PointF((float)addMaterial.CrEq, (float)addMaterial.NiEq);

            PointF pointInTheMiddleOfLine = GeometryHelper.GetPointInTheMiddle(pointForFirstMaterial, pointForSecondMaterial);

            PointF pointInTheMiddleOfLineWithTranslation = GeometryHelper.GetPointInTheMiddleWithTranslation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
            RedrawChart(pointForFirstMaterial, pointForSecondMaterial, pointForAddMaterial, pointInTheMiddleOfLine, pointInTheMiddleOfLineWithTranslation);
        }

        private void RedrawChart(PointF pointForFirstMaterial, PointF pointForSecondMaterial, PointF pointForAddMaterial, PointF pointInTheMiddleOfLine, PointF pointInTheMiddleOfLineWithTranslation)
        {
            _chart.Clean();

            // point for each material
            _chart.AddPoint(pointForFirstMaterial, Color.Crimson);
            _chart.AddPoint(pointForSecondMaterial, Color.OrangeRed);
            _chart.AddPoint(pointForAddMaterial, Color.DarkMagenta);

            // line between base materials
            _chart.AddLine(pointForFirstMaterial, pointForSecondMaterial, Color.GreenYellow);

            // all the rest
            _chart.AddPoint(pointInTheMiddleOfLine, Color.Blue);
            _chart.AddLine(pointInTheMiddleOfLine, pointForAddMaterial, Color.GreenYellow);
            _chart.AddPoint(pointInTheMiddleOfLineWithTranslation, Color.Red);

            _chart.Draw();
        }
    }
}

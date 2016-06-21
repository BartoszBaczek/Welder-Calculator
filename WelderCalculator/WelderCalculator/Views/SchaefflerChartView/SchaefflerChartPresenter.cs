using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Helpers;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.AddMaterialDatabaseView;
using WelderCalculator.Views.FastMaterialFactoryView;
using WelderCalculator.Views.MaterialDatabaseView;
using WelderCalculator.Helpers.SchaefflerHelpers;

namespace WelderCalculator.Views.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;
        private readonly DataConnector _dataConnector;
        private readonly IChart _chart;

        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetSchaefflerImages(),
                _dataConnector.GetSchaefflerChartSizingData());

            SetVisibilityCheckBoxesToTrue();
            RefreshSelectedMaterials();
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
        }

        public void OnLayerVisibilityChanged(string layerType, bool visibility)
        {
            if (!visibility)
                _chart.Layers.Remove(layerType);
            else
                _chart.Layers.Add(layerType);
        }

        private void SetVisibilityCheckBoxesToTrue()
        {
            _view.CrackingVisibleCheckBox = true;
            _view.PhaseVisibleCheckBox = true;
            _view.HashVisibleCheckBox = true;
            _view.XAxisVisibleCheckBox = true;
            _view.YAxisVisibleCheckBox = true;
            _view.PhaseLinesVisibleCheckBox = true;
        }

        public void OnFastMaterialButtonClicked()
        {
            var fastMaterialForm = new FastMaterialFactoryForm();
            fastMaterialForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnFirstBaseMaterialButtonClicked()
        {
            var materialDatabaseForm = new MaterialDatabaseForm(BaseMaterialDatabaseAccesibility.PartialForFirstMaterial);
            materialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnSecondBaseMaterialButtonClicked()
        {
            var materialDatabaseForm = new MaterialDatabaseForm(BaseMaterialDatabaseAccesibility.PartialForSecondMaterial);
            materialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnAdditionalMaterialButtonClicked()
        {
            var addMaterialDatabaseForm = new AddMaterialDatabaseForm(AdditiveMaterialDatabaseAccesibility.Partial);
            addMaterialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        private void RefreshSelectedMaterials()
        {
            BaseMaterial firstBaseMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            _view.FirstBaseMaterialTextBox = firstBaseMaterial.Name;

            BaseMaterial secondBaseMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            _view.SecondBaseMaterialTextBox = secondBaseMaterial.Name;

            AdditiveMaterial additiveMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            if (additiveMaterial != null)
                _view.AdditionalMaterialTextBox = additiveMaterial.Name;
        }

        public void OnCountButtonClicked()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if (!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100");
                return;
            }

            var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            PointF pointForFirstMaterial = new PointF((float)firstMaterial.CrEqSchaefflerAndDeLong, (float)firstMaterial.NiEqSchaeffler);

            var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            PointF pointForSecondMaterial = new PointF((float)secondMaterial.CrEqSchaefflerAndDeLong, (float)secondMaterial.NiEqSchaeffler);

            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            PointF pointForAddMaterial = new PointF((float)addMaterial.CrEqSchaefflerAndDeLong, (float)addMaterial.NiEqSchaeffler);

            PointF pointInTheMiddleOfLine = GeometryHelper.GetPointInTheMiddle(pointForFirstMaterial, pointForSecondMaterial);

            PointF pointInTheMiddleOfLineWithTranslation = GeometryHelper.GetPointInTheMiddleWithTranslation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
            RedrawChart(pointForFirstMaterial, pointForSecondMaterial, pointForAddMaterial, pointInTheMiddleOfLine, pointInTheMiddleOfLineWithTranslation);
            PrintNewMaterialDataForPoint(pointInTheMiddleOfLineWithTranslation);
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

        private void PrintNewMaterialDataForPoint(PointF newMaterialPoint)
        {
            var schaefflerMicrophaseHelper = new SchaefflerMicrophaseHelper();
            SchaefflerMicrophase newMaterialMicrophase = schaefflerMicrophaseHelper.GetMicrophaseForPoint(newMaterialPoint);

            switch (newMaterialMicrophase)
            {
                case SchaefflerMicrophase.FM:
                    _view.NewMaterialMicrophaseTextBox = "Ferrytyczno - martenzytyczna";
                    break;
                case SchaefflerMicrophase.M:
                    _view.NewMaterialMicrophaseTextBox = "Martenzytyczna";
                    break;
                case SchaefflerMicrophase.AM:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczno - martenzytyczna";
                    break;
                case SchaefflerMicrophase.A:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczna";
                    break;
                case SchaefflerMicrophase.MF:
                    _view.NewMaterialMicrophaseTextBox = "Martenzytyczno - ferrytyczna";
                    break;
                case SchaefflerMicrophase.AMF:
                    _view.NewMaterialMicrophaseTextBox = "Austeniticzno - martenzytyczno - ferrytyczna";
                    break;
                case SchaefflerMicrophase.AF:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczno - ferrytyczna";
                    break;
                case SchaefflerMicrophase.F:
                    _view.NewMaterialMicrophaseTextBox = "Ferrytyczna";
                    break;
                case SchaefflerMicrophase.Unknown:
                    _view.NewMaterialMicrophaseTextBox = "Poza wykresem";
                    break;
            }

            SchaefflerFerriteQuantity newMaterialFerriteQuantity = schaefflerMicrophaseHelper.GetFerriteQuantityForPoint(newMaterialPoint);

            if (newMaterialFerriteQuantity == SchaefflerFerriteQuantity.Unknown)
                _view.NewMaterialFerriteQuantityTextBox = "Nieznana";
            else
            {
                switch (newMaterialFerriteQuantity)
                {
                    case SchaefflerFerriteQuantity._0to5:
                        _view.NewMaterialFerriteQuantityTextBox = "0 - 5";
                        break;
                    case SchaefflerFerriteQuantity._5to10:
                        _view.NewMaterialFerriteQuantityTextBox = "5 - 10";
                        break;
                    case SchaefflerFerriteQuantity._10to20:
                        _view.NewMaterialFerriteQuantityTextBox = "10 - 20";
                        break;
                    case SchaefflerFerriteQuantity._20to40:
                        _view.NewMaterialFerriteQuantityTextBox = "20 - 40";
                        break;
                    case SchaefflerFerriteQuantity._40to80:
                        _view.NewMaterialFerriteQuantityTextBox = "40 - 80";
                        break;
                    case SchaefflerFerriteQuantity._80to100:
                        _view.NewMaterialFerriteQuantityTextBox = "80 - 100";
                        break;
                }

            }
        }
    }
}
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
using WelderCalculator.Helpers.DeLongHelpers;
using WelderCalculator.Views.SchaefflerMinimapView;
using System.Drawing.Imaging;

namespace WelderCalculator.Views.DeLongChartView
{
    public class DeLongChartPresenter
    {
        private readonly IDeLongChartView _view;
        private readonly DataConnector _dataConnector;
        private IChart _chart;
        private bool _someCountingsFinished = false;

        public DeLongChartPresenter(IDeLongChartView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetDeLongImages(),
                _dataConnector.GetDeLongChartSizingData());

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
            _view.RecomendedFerriteContentVisibleCheckBox = true;
            _view.PhaseVisibleCheckBox = true;
            _view.HashVisibleCheckBox = true;
            _view.XAxisVisibleCheckBox = true;
            _view.YAxisVisibleCheckBox = true;
            _view.PhaseLinesVisibleCheckBox = true;
            _view.FerriteContentVisibleCheckBox = true;
            _view.FerriteNumberVisibleCheckBox = true;
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

        public void OnShowMinimapButtonClicked()
        {
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (_view.AdditionalMaterialQuantity > 0 &&
                                                                                    _view.AdditionalMaterialQuantity < 100);
            if ((!(_view.AdditionalMaterialQuantity.HasValue && 
                additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
                                ||
                !_someCountingsFinished)
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100.\nUpewnij się że przeprowadzono obliczenia.");
                return;
            }

            var schaefflerDeLongMinimapForm = new SchaefflerMinimapForm(MinimapCombination.SchaefflerDeLong, _view.AdditionalMaterialQuantity.Value);
            schaefflerDeLongMinimapForm.ShowDialog();
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

            CountPointsAndLinesPositionAndDraw();

            _someCountingsFinished = true;
        }

        private void CountPointsAndLinesPositionAndDraw()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;

            var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            PointF pointForFirstMaterial = new PointF((float)firstMaterial.CrEqSchaefflerAndDeLong, (float)firstMaterial.NiEqDeLong);

            var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            PointF pointForSecondMaterial = new PointF((float)secondMaterial.CrEqSchaefflerAndDeLong, (float)secondMaterial.NiEqDeLong);

            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            PointF pointForAddMaterial = new PointF((float)addMaterial.CrEqSchaefflerAndDeLong, (float)addMaterial.NiEqDeLong);

            PointF pointInTheMiddleOfLine = GeometryHelper.GetPointInTheMiddle(pointForFirstMaterial, pointForSecondMaterial);

            PointF pointInTheMiddleOfLineWithTranslation = GeometryHelper.GetPointInTheMiddleWithTranslation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
            DrawCountedPointsAndLines(pointForFirstMaterial, pointForSecondMaterial, pointForAddMaterial, pointInTheMiddleOfLine, pointInTheMiddleOfLineWithTranslation);
            PrintNewMaterialDataForPoint(pointInTheMiddleOfLineWithTranslation);
        }

        private void DrawCountedPointsAndLines(PointF pointForFirstMaterial, PointF pointForSecondMaterial, PointF pointForAddMaterial, PointF pointInTheMiddleOfLine, PointF pointInTheMiddleOfLineWithTranslation)
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

        public void OnSaveToPDFButtonClicked()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if ((!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
                ||
                !_someCountingsFinished)
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100.\nUpewnij się że przeprowadzono obliczenia.");
                return;
            }

            Bitmap bitmap = new Bitmap(_view.DrawPanelWidth, _view.DrawPanelHeight);

            _chart = new Chart(Graphics.FromImage(bitmap),
                _dataConnector.GetDeLongImages(),
                _dataConnector.GetDeLongChartSizingData());
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
            CountPointsAndLinesPositionAndDraw();


            _dataConnector.SaveMainChartForPDF(bitmap);


            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetDeLongImages(),
                _dataConnector.GetDeLongChartSizingData());
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
            CountPointsAndLinesPositionAndDraw();
        }

        private void PrintNewMaterialDataForPoint(PointF newMaterialPoint)
        {
            var deLongMicrophaseHelper = new DeLongMicrophaseHelper();
            DeLongMicrophase newMaterialMicrophase = deLongMicrophaseHelper.GetMicrophaseForPoint(newMaterialPoint);

            switch (newMaterialMicrophase)
            {
                case DeLongMicrophase.A:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczna";
                    break;
                case DeLongMicrophase.AF:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczno - ferrytyczna";
                    break;
                case DeLongMicrophase.AM:
                    _view.NewMaterialMicrophaseTextBox = "Austenityczno - martenzytyczna";
                    break;
                case DeLongMicrophase.AMF:
                    _view.NewMaterialMicrophaseTextBox = "Austeniticzno - martenzytyczno - ferrytyczna";
                    break;
                case DeLongMicrophase.Unknown:
                    _view.NewMaterialMicrophaseTextBox = "Poza wykresem";
                    break;
            }

            DeLongFerriteQuantity newMaterialFerriteQuantity = deLongMicrophaseHelper.GetFerriteQuantityForPoint(newMaterialPoint);

            if (newMaterialFerriteQuantity == DeLongFerriteQuantity.Unknown)
            {
                _view.NewMaterialFerriteNumberTextBox = "Nieznana";
                _view.NewMaterialFerriteQuantityTextBox = "Nieznana";
            }
            else
            {
                switch (newMaterialFerriteQuantity)
                {
                    case DeLongFerriteQuantity._0to2:
                        _view.NewMaterialFerriteNumberTextBox = "0 - 2";
                        _view.NewMaterialFerriteQuantityTextBox = "0 - 2";
                        break;
                    case DeLongFerriteQuantity._2to4:
                        _view.NewMaterialFerriteNumberTextBox = "2 - 4";
                        _view.NewMaterialFerriteQuantityTextBox = "2 - 4";
                        break;
                    case DeLongFerriteQuantity._4to6:
                        _view.NewMaterialFerriteNumberTextBox = "4 - 6";
                        _view.NewMaterialFerriteQuantityTextBox = "4 - 6";
                        break;
                    case DeLongFerriteQuantity._6to8:
                        _view.NewMaterialFerriteNumberTextBox = "6 - 8";
                        _view.NewMaterialFerriteQuantityTextBox = "6 - 7.6";
                        break;
                    case DeLongFerriteQuantity._8to10:
                        _view.NewMaterialFerriteNumberTextBox = "8 - 10";
                        _view.NewMaterialFerriteQuantityTextBox = "7.6 - 9.2";
                        break;
                    case DeLongFerriteQuantity._10to12:
                        _view.NewMaterialFerriteNumberTextBox = "10 - 12";
                        _view.NewMaterialFerriteQuantityTextBox = "9.2 - 10.7";
                        break;
                    case DeLongFerriteQuantity._12to14:
                        _view.NewMaterialFerriteNumberTextBox = "12 - 14";
                        _view.NewMaterialFerriteQuantityTextBox = "10.7 - 12.3";
                        break;
                    case DeLongFerriteQuantity._14to16:
                        _view.NewMaterialFerriteNumberTextBox = "14 - 16";
                        _view.NewMaterialFerriteQuantityTextBox = "12.3 - 13.8";
                        break;
                    case DeLongFerriteQuantity._16to18:
                        _view.NewMaterialFerriteNumberTextBox = "16 - 18";
                        _view.NewMaterialFerriteQuantityTextBox = "13.8 +";
                        break;
                    case DeLongFerriteQuantity._18Plus:
                        _view.NewMaterialFerriteNumberTextBox = "18 +";
                        _view.NewMaterialFerriteQuantityTextBox = "13.8 +";
                        break;
                }

            }
        }
    }
}

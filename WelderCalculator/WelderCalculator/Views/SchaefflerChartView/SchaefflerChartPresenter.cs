using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.AddMaterialDatabaseView;
using WelderCalculator.Views.FastMaterialFactoryView;
using WelderCalculator.Views.MaterialDatabaseView;

namespace WelderCalculator.Views.SchaefflerChartView
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
            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas), _dataConnector.GetSchaefflerImages());

            SetVisibilityCheckBoxesToTrue();
            RefreshSelectedMaterials();
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.Resize(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
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
            _chart.Clean();
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;

            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if (additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100)
            {
                var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
                PointF pointForFirstMaterial = new PointF((float)firstMaterial.CrEq, (float)firstMaterial.NiEq);
                _chart.AddPoint(pointForFirstMaterial, Color.Crimson);

                var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
                PointF pointForSecondMaterial = new PointF((float)secondMaterial.CrEq, (float)secondMaterial.NiEq);
                _chart.AddPoint(pointForSecondMaterial, Color.OrangeRed);

                var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
                PointF pointForAddMaterial = new PointF((float)addMaterial.CrEq, (float)addMaterial.NiEq);
                _chart.AddPoint(pointForAddMaterial, Color.DarkMagenta);

                //lineBetweenTwoBaseMaterials
                _chart.AddLine(pointForFirstMaterial, pointForSecondMaterial, Color.GreenYellow);

                //drawPointInTheMiddleOfLine
                PointF pointInTheMiddleOfLine = GetPointBetweenTwoOthers(pointForFirstMaterial, pointForSecondMaterial);
                _chart.AddPoint(pointInTheMiddleOfLine, Color.Blue);

                //draw line between point in the middle of line and addmaterial
                _chart.AddLine(pointInTheMiddleOfLine, pointForAddMaterial, Color.GreenYellow);

                //draw shit
                PointF pointInTheMiddleOfLineWithTranslation = GetPointBetweenTwoOthersWithTranlation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
                _chart.AddPoint(pointInTheMiddleOfLineWithTranslation, Color.Red);

                _chart.Draw();
            }
            else
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100");
            }
        }

        private PointF GetPointBetweenTwoOthers(PointF point1, PointF point2)
        {
            return new PointF(0.5f * (point1.X + point2.X), 0.5f * (point1.Y + point2.Y));
        }

        private PointF GetPointBetweenTwoOthersWithTranlation(double translation, PointF point1, PointF point2)
        {
            //transaltion should be number from 0 - 1. Point1 should be at least down and left to point2.
            PointF point = new PointF(
                point1.X + (float) translation*(point2.X - point1.X),
                point1.Y + (float) translation*(point2.Y - point1.Y)
                );

            return point;
        }
    }
}

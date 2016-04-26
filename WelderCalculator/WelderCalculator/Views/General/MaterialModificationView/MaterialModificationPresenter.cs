using System;
using System.Linq;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.General.MaterialModificationView
{
    public class MaterialModificationPresenter
    {
        private readonly IMaterialModificationView _view;
        private readonly DataConnector _dataConnector;

        private readonly WindowMode.Mode _workingMode;
        private readonly object _normUnderConstruction;

        public MaterialModificationPresenter(IMaterialModificationView view, object norm)                               //used when adding new material
        {
            _view = view;
            _dataConnector = new DataConnector();
            view.Presenter = this;
            _workingMode = WindowMode.Mode.AddNew;

            if (_view.MaterialType == MaterialType.BaseMaterial)
                _normUnderConstruction = norm as BaseNorm;
            else
                _normUnderConstruction = norm as AdditiveNorm;
        }

        public MaterialModificationPresenter(IMaterialModificationView view, object norm, object materialToModify)      //used when modifying material
        {
            _workingMode = WindowMode.Mode.ModifyCurrent;
            _view = view;
            _dataConnector = new DataConnector();
            view.Presenter = this;
            if (_view.MaterialType == MaterialType.BaseMaterial)
                _normUnderConstruction = norm as BaseNorm;
            else
                _normUnderConstruction = norm as AdditiveNorm;

            BindToControls(materialToModify);
        }

        private void BindToControls(object materialToBind)
        {
            if (_view.MaterialType == MaterialType.BaseMaterial)
            {
                var material = materialToBind as BaseMaterial;
                _view.NameTextbox = material.Name;
                _view.NumberTextbox = material.Number;

                _view.GuidTextbox = material.GuidNumber.ToString();

                var e = material.GetElement(Category.OfElement.C);
                _view.CMintextbox = e.Min;
                _view.CMaxtextbox = e.Max;
                _view.CRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Si);
                _view.SiMintextbox = e.Min;
                _view.SiMaxtextbox = e.Max;
                _view.SiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Mn);
                _view.MnMintextbox = e.Min;
                _view.MnMaxtextbox = e.Max;
                _view.MnRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.P);
                _view.PMintextbox = e.Min;
                _view.PMaxtextbox = e.Max;
                _view.PRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.S);
                _view.SMintextbox = e.Min;
                _view.SMaxtextbox = e.Max;
                _view.SRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.N);
                _view.NMintextbox = e.Min;
                _view.NMaxtextbox = e.Max;
                _view.NRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Cr);
                _view.CrMintextbox = e.Min;
                _view.CrMaxtextbox = e.Max;
                _view.CrRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Mo);
                _view.MoMintextbox = e.Min;
                _view.MoMaxtextbox = e.Max;
                _view.MoRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Nb);
                _view.NbMintextbox = e.Min;
                _view.NbMaxtextbox = e.Max;
                _view.NbRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Ni);
                _view.NiMintextbox = e.Min;
                _view.NiMaxtextbox = e.Max;
                _view.NiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Ti);
                _view.TiMintextbox = e.Min;
                _view.TiMaxtextbox = e.Max;
                _view.TiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Al);
                _view.AlMintextbox = e.Min;
                _view.AlMaxtextbox = e.Max;
                _view.AlRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.V);
                _view.VMintextbox = e.Min;
                _view.VMaxtextbox = e.Max;
                _view.VRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Cu);
                _view.CuMintextbox = e.Min;
                _view.CuMaxtextbox = e.Max;
                _view.CuRealtextbox = e.RealValue;
            }
            else
            {
                var material = materialToBind as AdditiveMaterial;

                _view.GuidTextbox = material.GuidNumber.ToString();
                _view.NameTextbox = material.Name;

                var e = material.GetElement(Category.OfElement.C);
                _view.CMintextbox = e.Min;
                _view.CMaxtextbox = e.Max;
                _view.CRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Si);
                _view.SiMintextbox = e.Min;
                _view.SiMaxtextbox = e.Max;
                _view.SiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Mn);
                _view.MnMintextbox = e.Min;
                _view.MnMaxtextbox = e.Max;
                _view.MnRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.P);
                _view.PMintextbox = e.Min;
                _view.PMaxtextbox = e.Max;
                _view.PRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.S);
                _view.SMintextbox = e.Min;
                _view.SMaxtextbox = e.Max;
                _view.SRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.N);
                _view.NMintextbox = e.Min;
                _view.NMaxtextbox = e.Max;
                _view.NRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Cr);
                _view.CrMintextbox = e.Min;
                _view.CrMaxtextbox = e.Max;
                _view.CrRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Mo);
                _view.MoMintextbox = e.Min;
                _view.MoMaxtextbox = e.Max;
                _view.MoRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Nb);
                _view.NbMintextbox = e.Min;
                _view.NbMaxtextbox = e.Max;
                _view.NbRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Ni);
                _view.NiMintextbox = e.Min;
                _view.NiMaxtextbox = e.Max;
                _view.NiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Ti);
                _view.TiMintextbox = e.Min;
                _view.TiMaxtextbox = e.Max;
                _view.TiRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.Cu);
                _view.CuMintextbox = e.Min;
                _view.CuMaxtextbox = e.Max;
                _view.CuRealtextbox = e.RealValue;

                e = material.GetElement(Category.OfElement.V);
                _view.VMintextbox = e.Min;
                _view.VMaxtextbox = e.Max;
                _view.VRealtextbox = e.RealValue;
            }
            
        }

        private BaseMaterial BuildBaseMaterial()
        {
            var material = new BaseMaterial();
            material.CreateBasicListOfElements();

            material.Name = _view.NameTextbox;
            material.Number = _view.NumberTextbox;

            material.GetElement(Category.OfElement.C).Min = _view.CMintextbox;
            material.GetElement(Category.OfElement.C).Max = _view.CMaxtextbox;
            material.GetElement(Category.OfElement.C).RealValue = _view.CRealtextbox;

            material.GetElement(Category.OfElement.Si).Min = _view.SiMintextbox;
            material.GetElement(Category.OfElement.Si).Max = _view.SiMaxtextbox;
            material.GetElement(Category.OfElement.Si).RealValue = _view.SiRealtextbox;

            material.GetElement(Category.OfElement.Mn).Min = _view.MnMintextbox;
            material.GetElement(Category.OfElement.Mn).Max = _view.MnMaxtextbox;
            material.GetElement(Category.OfElement.Mn).RealValue = _view.MnRealtextbox;

            material.GetElement(Category.OfElement.P).Min = _view.PMintextbox;
            material.GetElement(Category.OfElement.P).Max = _view.PMaxtextbox;
            material.GetElement(Category.OfElement.P).RealValue = _view.PRealtextbox;

            material.GetElement(Category.OfElement.S).Min = _view.SMintextbox;
            material.GetElement(Category.OfElement.S).Max = _view.SMaxtextbox;
            material.GetElement(Category.OfElement.S).RealValue = _view.SRealtextbox;

            material.GetElement(Category.OfElement.N).Min = _view.NMintextbox;
            material.GetElement(Category.OfElement.N).Max = _view.NMaxtextbox;
            material.GetElement(Category.OfElement.N).RealValue = _view.NRealtextbox;

            material.GetElement(Category.OfElement.Cr).Min = _view.CrMintextbox;
            material.GetElement(Category.OfElement.Cr).Max = _view.CrMaxtextbox;
            material.GetElement(Category.OfElement.Cr).RealValue = _view.CrRealtextbox;

            material.GetElement(Category.OfElement.Mo).Min = _view.MoMintextbox;
            material.GetElement(Category.OfElement.Mo).Max = _view.MoMaxtextbox;
            material.GetElement(Category.OfElement.Mo).RealValue = _view.MoRealtextbox;

            material.GetElement(Category.OfElement.Nb).Min = _view.NbMintextbox;
            material.GetElement(Category.OfElement.Nb).Max = _view.NbMaxtextbox;
            material.GetElement(Category.OfElement.Nb).RealValue = _view.NbRealtextbox;

            material.GetElement(Category.OfElement.Ni).Min = _view.NiMintextbox;
            material.GetElement(Category.OfElement.Ni).Max = _view.NiMaxtextbox;
            material.GetElement(Category.OfElement.Ni).RealValue = _view.NiRealtextbox;

            material.GetElement(Category.OfElement.Ti).Min = _view.TiMintextbox;
            material.GetElement(Category.OfElement.Ti).Max = _view.TiMaxtextbox;
            material.GetElement(Category.OfElement.Ti).RealValue = _view.TiRealtextbox;

            material.GetElement(Category.OfElement.Al).Min = _view.AlMintextbox;
            material.GetElement(Category.OfElement.Al).Max = _view.AlMaxtextbox;
            material.GetElement(Category.OfElement.Al).RealValue = _view.AlRealtextbox;

            material.GetElement(Category.OfElement.V).Min = _view.VMintextbox;
            material.GetElement(Category.OfElement.V).Max = _view.VMaxtextbox;
            material.GetElement(Category.OfElement.V).RealValue = _view.VRealtextbox;

            material.GetElement(Category.OfElement.Cu).Min = _view.CuMintextbox;
            material.GetElement(Category.OfElement.Cu).Max = _view.CuMaxtextbox;
            material.GetElement(Category.OfElement.Cu).RealValue = _view.CuRealtextbox;

            switch (_workingMode)
            {
                case WindowMode.Mode.AddNew:
                    material.GuidNumber = Guid.NewGuid();
                    break;
                case WindowMode.Mode.ModifyCurrent:
                    material.GuidNumber = Guid.Parse(_view.GuidTextbox);
                    break;
            }

            return material;
        }

        private AdditiveMaterial BuildAdditiveMaterial()
        {
            var material = new AdditiveMaterial();
            material.CreateBasicListOfElements();

            material.Name = _view.NameTextbox;
            material.GetElement(Category.OfElement.C).Min = _view.CMintextbox;
            material.GetElement(Category.OfElement.C).Max = _view.CMaxtextbox;
            material.GetElement(Category.OfElement.C).RealValue = _view.CRealtextbox;

            material.GetElement(Category.OfElement.Si).Min = _view.SiMintextbox;
            material.GetElement(Category.OfElement.Si).Max = _view.SiMaxtextbox;
            material.GetElement(Category.OfElement.Si).RealValue = _view.SiRealtextbox;

            material.GetElement(Category.OfElement.Mn).Min = _view.MnMintextbox;
            material.GetElement(Category.OfElement.Mn).Max = _view.MnMaxtextbox;
            material.GetElement(Category.OfElement.Mn).RealValue = _view.MnRealtextbox;

            material.GetElement(Category.OfElement.P).Min = _view.PMintextbox;
            material.GetElement(Category.OfElement.P).Max = _view.PMaxtextbox;
            material.GetElement(Category.OfElement.P).RealValue = _view.PRealtextbox;

            material.GetElement(Category.OfElement.S).Min = _view.SMintextbox;
            material.GetElement(Category.OfElement.S).Max = _view.SMaxtextbox;
            material.GetElement(Category.OfElement.S).RealValue = _view.SRealtextbox;

            material.GetElement(Category.OfElement.N).Min = _view.NMintextbox;
            material.GetElement(Category.OfElement.N).Max = _view.NMaxtextbox;
            material.GetElement(Category.OfElement.N).RealValue = _view.NRealtextbox;

            material.GetElement(Category.OfElement.Cr).Min = _view.CrMintextbox;
            material.GetElement(Category.OfElement.Cr).Max = _view.CrMaxtextbox;
            material.GetElement(Category.OfElement.Cr).RealValue = _view.CrRealtextbox;

            material.GetElement(Category.OfElement.Mo).Min = _view.MoMintextbox;
            material.GetElement(Category.OfElement.Mo).Max = _view.MoMaxtextbox;
            material.GetElement(Category.OfElement.Mo).RealValue = _view.MoRealtextbox;

            material.GetElement(Category.OfElement.Nb).Min = _view.NbMintextbox;
            material.GetElement(Category.OfElement.Nb).Max = _view.NbMaxtextbox;
            material.GetElement(Category.OfElement.Nb).RealValue = _view.NbRealtextbox;

            material.GetElement(Category.OfElement.Ni).Min = _view.NiMintextbox;
            material.GetElement(Category.OfElement.Ni).Max = _view.NiMaxtextbox;
            material.GetElement(Category.OfElement.Ni).RealValue = _view.NiRealtextbox;

            material.GetElement(Category.OfElement.Ti).Min = _view.TiMintextbox;
            material.GetElement(Category.OfElement.Ti).Max = _view.TiMaxtextbox;
            material.GetElement(Category.OfElement.Ti).RealValue = _view.TiRealtextbox;

            material.GetElement(Category.OfElement.Cu).Min = _view.CuMintextbox;
            material.GetElement(Category.OfElement.Cu).Max = _view.CuMaxtextbox;
            material.GetElement(Category.OfElement.Cu).RealValue = _view.CuRealtextbox;

            material.GetElement(Category.OfElement.V).Min = _view.VMintextbox;
            material.GetElement(Category.OfElement.V).Max = _view.VMaxtextbox;
            material.GetElement(Category.OfElement.V).RealValue = _view.VRealtextbox;

            switch (_workingMode)
            {
                case WindowMode.Mode.AddNew:
                    material.GuidNumber = Guid.NewGuid();
                    break;
                case WindowMode.Mode.ModifyCurrent:
                    material.GuidNumber = Guid.Parse(_view.GuidTextbox);
                    break;
            }
            return material;
        }

        public void OnApplyButtonClicked()
        {
            if (_view.MaterialType == MaterialType.BaseMaterial)
            {
                if (_workingMode == WindowMode.Mode.ModifyCurrent)
                {
                    var materialAfterModification = BuildBaseMaterial();
                    var materialBeforeModification = _dataConnector.GetBaseMaterial(Guid.Parse(_view.GuidTextbox),
                        (_normUnderConstruction as BaseNorm).Name);

                    if (materialBeforeModification.Equals(materialAfterModification))
                    {
                        MessageBox.Show("Dane materiału nie zostały zmienione.", "Brak zmian", MessageBoxButtons.OK);
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show("Czy na pewno chcesz nadpisać dane materiału?", "plepleple",
                            MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            var materialToModify =
                                (_normUnderConstruction as BaseNorm).Materials.Where(m => m.GuidNumber == Guid.Parse(_view.GuidTextbox));

                            (_normUnderConstruction as BaseNorm).Materials = (_normUnderConstruction as BaseNorm).Materials.Except(materialToModify).ToList();
                            (_normUnderConstruction as BaseNorm).Materials.Add(materialAfterModification);

                            _dataConnector.RemoveBaseNorm((_normUnderConstruction as BaseNorm).Name);

                            _dataConnector.SaveBaseNorm((_normUnderConstruction as BaseNorm));

                            _view.CancelDialog();
                        }
                    }
                }
                else if (_workingMode == WindowMode.Mode.AddNew)
                {
                    var materialAfterModification = BuildBaseMaterial();

                    var dialogResult = MessageBox.Show("Czy na pewno chcesz dodac nowy materiał?", "plepleple",
                        MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        _dataConnector.RemoveBaseNorm((_normUnderConstruction as BaseNorm).Name);
                        (_normUnderConstruction as BaseNorm).Materials.Add(materialAfterModification);
                        _dataConnector.SaveBaseNorm((_normUnderConstruction as BaseNorm));
                        _view.CancelDialog();
                    }

                }
            }
            else
            {
                if (_workingMode == WindowMode.Mode.ModifyCurrent)
                {
                    var materialAfterModification = BuildAdditiveMaterial();
                    var materialBeforeModification = _dataConnector.GetAdditiveMaterial(Guid.Parse(_view.GuidTextbox),
                        (_normUnderConstruction as AdditiveNorm).Name);

                    if (materialBeforeModification.Equals(materialAfterModification))
                    {
                        MessageBox.Show("Dane materiału nie zostały zmienione.", "Brak zmian", MessageBoxButtons.OK);
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show("Czy na pewno chcesz nadpisać dane materiału?", "plepleple",
                            MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            var materialToModify =
                                (_normUnderConstruction as AdditiveNorm).Materials.Where(m => m.GuidNumber == Guid.Parse(_view.GuidTextbox));

                            (_normUnderConstruction as AdditiveNorm).Materials = (_normUnderConstruction as AdditiveNorm).Materials.Except(materialToModify).ToList();
                            (_normUnderConstruction as AdditiveNorm).Materials.Add(materialAfterModification);

                            _dataConnector.RemoveAdditiveNorm((_normUnderConstruction as AdditiveNorm).Name);

                            _dataConnector.SaveAdditiveNorm((_normUnderConstruction as AdditiveNorm));

                            _view.CancelDialog();
                        }
                    }
                }
                else if (_workingMode == WindowMode.Mode.AddNew)
                {
                    var materialAfterModification = BuildAdditiveMaterial();

                    var dialogResult = MessageBox.Show("Czy na pewno chcesz dodac nowy materiał?", "plepleple",
                        MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        _dataConnector.RemoveAdditiveNorm((_normUnderConstruction as AdditiveNorm).Name);
                        (_normUnderConstruction as AdditiveNorm).Materials.Add(materialAfterModification);
                        _dataConnector.SaveAdditiveNorm((_normUnderConstruction as AdditiveNorm));
                        _view.CancelDialog();
                    }

                }
            }
        }

        public void OnCancelButtonClicked()
        {
            if (_view.MaterialType == MaterialType.BaseMaterial)
            {
                if (_workingMode == WindowMode.Mode.ModifyCurrent)
                {
                    var materialAfterModification = BuildBaseMaterial();
                    var materialBeforeModification = _dataConnector.GetBaseMaterial(Guid.Parse(_view.GuidTextbox),
                        (_normUnderConstruction as BaseNorm).Name);

                    if (materialBeforeModification.Equals(materialAfterModification))
                    {
                        _view.CancelDialog();
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show("Dane materiału nie zostały zapisane. Czy chcesz wyjść?", "plepleple",
                            MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            _view.CancelDialog();
                        }
                    }
                }
            }
            else
            {
                if (_workingMode == WindowMode.Mode.ModifyCurrent)
                {
                    var materialAfterModification = BuildAdditiveMaterial();
                    var materialBeforeModification = _dataConnector.GetAdditiveMaterial(Guid.Parse(_view.GuidTextbox),
                        (_normUnderConstruction as AdditiveNorm).Name);

                    if (materialBeforeModification.Equals(materialAfterModification))
                    {
                        _view.CancelDialog();
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show("Dane materiału nie zostały zapisane. Czy chcesz wyjść?", "plepleple",
                            MessageBoxButtons.OKCancel);
                        if (dialogResult == DialogResult.OK)
                        {
                            _view.CancelDialog();
                        }
                    }
                }
            }
            
        }

        public void AutofillAllElementsData()
        {
            //c
            double? minValue = _view.CMintextbox;
            double? maxValue = _view.CMaxtextbox;
            double? realValue = _view.CRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.CMintextbox = minValue;
            _view.CMaxtextbox = maxValue;
            _view.CRealtextbox = realValue;
            //si
            minValue = _view.SiMintextbox;
            maxValue = _view.SiMaxtextbox;
            realValue = _view.SiRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.SiMintextbox = minValue;
            _view.SiMaxtextbox = maxValue;
            _view.SiRealtextbox = realValue;
            //mn
            minValue = _view.MnMintextbox;
            maxValue = _view.MnMaxtextbox;
            realValue = _view.MnRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.MnMintextbox = minValue;
            _view.MnMaxtextbox = maxValue;
            _view.MnRealtextbox = realValue;
            //p
            minValue = _view.PMintextbox;
            maxValue = _view.PMaxtextbox;
            realValue = _view.PRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.PMintextbox = minValue;
            _view.PMaxtextbox = maxValue;
            _view.PRealtextbox = realValue;
            //s
            minValue = _view.SMintextbox;
            maxValue = _view.SMaxtextbox;
            realValue = _view.SRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.SMintextbox = minValue;
            _view.SMaxtextbox = maxValue;
            _view.SRealtextbox = realValue;
            //n
            minValue = _view.NMintextbox;
            maxValue = _view.NMaxtextbox;
            realValue = _view.NRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.NMintextbox = minValue;
            _view.NMaxtextbox = maxValue;
            _view.NRealtextbox = realValue;
            //cr
            minValue = _view.CrMintextbox;
            maxValue = _view.CrMaxtextbox;
            realValue = _view.CrRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.CrMintextbox = minValue;
            _view.CrMaxtextbox = maxValue;
            _view.CrRealtextbox = realValue;
            //mo
            minValue = _view.MoMintextbox;
            maxValue = _view.MoMaxtextbox;
            realValue = _view.MoRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.MoMintextbox = minValue;
            _view.MoMaxtextbox = maxValue;
            _view.MoRealtextbox = realValue;
            //nb
            minValue = _view.NbMintextbox;
            maxValue = _view.NbMaxtextbox;
            realValue = _view.NbRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.NbMintextbox = minValue;
            _view.NbMaxtextbox = maxValue;
            _view.NbRealtextbox = realValue;
            //ni
            minValue = _view.NiMintextbox;
            maxValue = _view.NiMaxtextbox;
            realValue = _view.NiRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.NiMintextbox = minValue;
            _view.NiMaxtextbox = maxValue;
            _view.NiRealtextbox = realValue;
            //Ti
            minValue = _view.TiMintextbox;
            maxValue = _view.TiMaxtextbox;
            realValue = _view.TiRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.TiMintextbox = minValue;
            _view.TiMaxtextbox = maxValue;
            _view.TiRealtextbox = realValue;
            //Al
            minValue = _view.AlMintextbox;
            maxValue = _view.AlMaxtextbox;
            realValue = _view.AlRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.AlMintextbox = minValue;
            _view.AlMaxtextbox = maxValue;
            _view.AlRealtextbox = realValue;
            //Cu
            minValue = _view.CuMintextbox;
            maxValue = _view.CuMaxtextbox;
            realValue = _view.CuRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.CuMintextbox = minValue;
            _view.CuMaxtextbox = maxValue;
            _view.CuRealtextbox = realValue;
            //V
            minValue = _view.VMintextbox;
            maxValue = _view.VMaxtextbox;
            realValue = _view.VRealtextbox;
            AutoFillElementData(ref minValue, ref maxValue, ref realValue);
            _view.VMintextbox = minValue;
            _view.VMaxtextbox = maxValue;
            _view.VRealtextbox = realValue;
        }

        private void AutoFillElementData(ref double? minValue, ref double? maxValue, ref double? realValue)
        {
            //no values given
            if (!minValue.HasValue && !maxValue.HasValue && !realValue.HasValue)
            {
                minValue = 0;
                maxValue = 0;
                realValue = 0;
            }
            //min and max values given
            else if (minValue.HasValue && maxValue.HasValue && !realValue.HasValue)
            {
                realValue = minValue / 2.0f + maxValue / 2.0f;
            }
            //maxValue given, but minValue not
            else if (!minValue.HasValue && maxValue.HasValue && !realValue.HasValue)
            {
                minValue = 0;
                realValue = minValue / 2.0f + maxValue / 2.0f;
            }
            //real value is not given
            else if (!realValue.HasValue)
            {
                realValue = 0;
                if (!minValue.HasValue)
                    minValue = 0;
                if (!maxValue.HasValue)
                    maxValue = 0;
            }
        }
    }
}

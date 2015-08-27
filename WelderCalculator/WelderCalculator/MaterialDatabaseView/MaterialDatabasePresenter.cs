using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Serialization;

namespace WelderCalculator.MaterialDatabaseView
{
    public class MaterialDatabasePresenter
    {
        private readonly IMaterialDatabaseView _view;

        private readonly IRepository _repository;
        private readonly MaterialDataReader _materialDataReader;

        public MaterialDatabasePresenter(IMaterialDatabaseView view,  IRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _materialDataReader = new MaterialDataReader();
        }

        public void Init()
        {
            LoadNormsComboBox();
            MakeAllCheckBoxesChecked();
        }

        public void LoadNormsComboBox()  
        {
            _view.NormsList = _materialDataReader.GetSortedListOfMaterialsNorms();
        }

        public void MakeAllCheckBoxesChecked()
        {
            _view.CcheckBox = true;
            _view.SiCheckBox = true;
            _view.MnCheckBox = true;
            _view.PcheckBox = true;
            _view.ScheckBox = true;
            _view.NcheckBox = true;
            _view.CrCheckBox = true;
            _view.MoCheckBox = true;
            _view.NbCheckBox = true;
            _view.NiCheckBox = true;
            _view.TiCheckBox = true;
            _view.AlCheckBox = true;
        }

        public void UpdateNormComboBoxSelection()
        {
            int selectedNorm = _view.SelectedNorm >= 0 ? _view.SelectedNorm : 0;
            _view.SelectedNorm = selectedNorm;
        }

        public void BindDataSourceToDataGridView()
        {
            _view.GridSource = new List<Material>();
        }
    }
}

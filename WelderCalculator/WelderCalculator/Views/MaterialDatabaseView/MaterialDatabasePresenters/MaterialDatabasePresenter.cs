using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.MaterialDatabaseView;
using WelderCalculator.MaterialModificationView.Serialization;

namespace WelderCalculator.Views.MaterialDatabaseView.MaterialDatabasePresenters
{
    public abstract class MaterialDatabasePresenter
    {
        protected IMaterialDatabaseView _view;
        protected DataConnector _dataConnector;

        public abstract void Init();

        public abstract void OnSelectedIndexChanged();

        public abstract void OnMaterialCheckBoxChanged(string elementName);

        public abstract void OnViewOptionsCheckBoxChanged(string option);

        public abstract void OnElementsOrderPropertiesButtonClicked();

        public abstract void Refresh();

        public abstract void OnSelectedDataGridViewRowChanged();

        public abstract void OnAddMaterialButtonClicked();

        public abstract void OnEditMaterialButtonClicked();

        public abstract void OnDeleteMaterialButtonClicked();

        public abstract void OnAddNormButtonClicked();

        public abstract void OnDeleteNormButtonClicked();
    }
}

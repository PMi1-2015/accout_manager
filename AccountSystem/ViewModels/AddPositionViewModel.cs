using AccountSystem.Data.models;
using AccountSystem.Services;
using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity.Attributes;

namespace AccountSystem.ViewModels
{
    public class AddPositionViewModel : BaseViewModel
    {
        private IPositionService _positionService;

        public ICommand BackAction { get; set; }

        private ICommand _saveProjecAction;
        public ICommand SavePositionAction { get { return _saveProjecAction; } }

        public AddPositionViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _positionService = ServiceLocator.Instance.GetService<IPositionService>();

            BackAction = new RelayCommand(Back);
            _saveProjecAction = new RelayCommand(SavePosition, CanSavePosition);

        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = new PositionsCrudViewModel(_navigationViewModel);
        }

        private void SavePosition(object obj)
        {
            Position position = new Position
            {
                Name = this.PositionName,
                Description = this.PositionDescription,
            };

            _positionService.SavePosition(position);
            BackAction?.Execute(null);
        }

        private bool CanSavePosition(object obj)
        {
            if (String.IsNullOrEmpty(PositionName))
            {
                ErrorMessage = "Position name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(PositionDescription))
            {
                ErrorMessage = "Position description can't be empty";
                return false;
            }

            return true;
        }

        private NavigationViewModel _navigationViewModel;

        private String _positionName;
        public String PositionName
        {
            get { return _positionName; }
            set { _positionName = value; OnPoropertyChanged("PositionName"); }
        }

        private String _projecDescription;
        public String PositionDescription
        {
            get { return _projecDescription; }
            set { _projecDescription = value; OnPoropertyChanged("PositionDescription"); }
        }

        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPoropertyChanged("ErrorMessage"); }
        }
    }
}

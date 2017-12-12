using AccountSystem.Data.models;
using AccountSystem.Services;
using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    class PositionUpdateViewModel : BaseViewModel
    {
        private PositionsViewModel _searchViewModel;

        public String FirstButtonText => IsEditable ? "Save Changes" : "Update";
        public String SecondButtonText => IsEditable ? "Reset" : "Delete";

        public ICommand FirstButtonAction => IsEditable ? UpdatePositionAction : MakeEditableAction;
        public ICommand SecondButtonAction => IsEditable ? ResetChangesAction : DeletePositionAction;

        private Position _positionEntity;
        private IPositionService _positionService;

        public ICommand BackAction { get; set; }

        private ICommand _updatePositionAction;
        public ICommand UpdatePositionAction => _updatePositionAction;

        private ICommand _deletePositionAction;
        public ICommand DeletePositionAction => _deletePositionAction;

        private ICommand _resetChangesAction;
        public ICommand ResetChangesAction => _resetChangesAction;

        private ICommand _makeEditableAction;
        public ICommand MakeEditableAction => _makeEditableAction;

        public PositionUpdateViewModel(NavigationViewModel navigationViewModel, PositionsViewModel searchModel, Position position)
        {
            _searchViewModel = searchModel;
            _positionEntity = position;
            _position = new PositionViewModel(position);

            _navigationViewModel = navigationViewModel;
            _positionService = ServiceLocator.Instance.GetService<IPositionService>();

            BackAction = new RelayCommand(Back);

            _updatePositionAction = new RelayCommand(UpdatePosition, CanUpdatePosition);
            _deletePositionAction = new RelayCommand(DeletePosition);
            _makeEditableAction = new RelayCommand(MakeEditable, CanMakeEditable);
            _resetChangesAction = new RelayCommand(ResetChanges, CanResetChanges);
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = _searchViewModel;
            _searchViewModel.SearchCommand.Execute(null);
        }

        private void UpdatePosition(object obj)
        {
            _positionEntity.Name = _position.PositionName;
            _positionEntity.Description = _position.PositionDescription;
           
            _positionService.UpdatePosition(_positionEntity);
            IsEditable = false;
        }

        private bool CanUpdatePosition(object obj)
        {
            if (String.IsNullOrEmpty(_position.PositionName))
            {
                ErrorMessage = "Position name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(_position.PositionDescription))
            {
                ErrorMessage = "Position description can't be empty";
                return false;
            }
           
            return true;
        }

        private void DeletePosition(object obj)
        {
            _positionService.DeletePosition(_positionEntity);
            Back(null);
        }

        private void ResetChanges(object obj)
        {
            Position = new PositionViewModel(_positionEntity);
        }

        private bool CanResetChanges(object obj) => _isEditable;

        private void MakeEditable(object obj)
        {
            IsEditable = true;
        }
        private bool CanMakeEditable(object obj) => !_isEditable;

        private NavigationViewModel _navigationViewModel;


        private PositionViewModel _position;
        public PositionViewModel Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged("Position"); }
        }

        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged("ErrorMessage"); }
        }
        private bool _isEditable = false;
        public Boolean IsEditable
        {
            get { return _isEditable; }
            set { _isEditable = value; OnPropertyChanged("IsEditable"); ButtonChange(); }
        }

        private void ButtonChange()
        {
            OnPropertyChanged("FirstButtonText");
            OnPropertyChanged("SecondButtonText");
            OnPropertyChanged("FirstButtonAction");
            OnPropertyChanged("SecondButtonAction");
        }
    }
}

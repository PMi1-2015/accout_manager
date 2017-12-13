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
    class EmployeePositionsUpdateViewModel : BaseViewModel
    {
        private EmployeePositionsViewModel _searchViewModel;

        public String FirstButtonText => IsEditable ? "Save Changes" : "Update";
        public String SecondButtonText => IsEditable ? "Reset" : "Delete";

        public ICommand FirstButtonAction => IsEditable ? UpdateEmployeePositionsAction : MakeEditableAction;
        public ICommand SecondButtonAction => IsEditable ? ResetChangesAction : DeleteEmployeePositionsAction;

        private EmployeePosition _employeePosEntity;
        private IEmployeePositionsService _employeePosService;

        public ICommand BackAction { get; set; }

        private ICommand _updateEmployeePositionsAction;
        public ICommand UpdateEmployeePositionsAction => _updateEmployeePositionsAction;

        private ICommand _deleteEmployeePositionsAction;
        public ICommand DeleteEmployeePositionsAction => _deleteEmployeePositionsAction;

        private ICommand _resetChangesAction;
        public ICommand ResetChangesAction => _resetChangesAction;

        private ICommand _makeEditableAction;
        public ICommand MakeEditableAction => _makeEditableAction;

        public EmployeePositionsUpdateViewModel(NavigationViewModel navigationViewModel, EmployeePositionsViewModel searchModel, EmployeePosition pos)
        {
            _searchViewModel = searchModel;
            _employeePosEntity = pos;
            _employeePosition = new EmployeePositionViewModel(pos);

            _navigationViewModel = navigationViewModel;
            _employeePosService = ServiceLocator.Instance.GetService<IEmployeePositionsService>();

            BackAction = new RelayCommand(Back);

            _updateEmployeePositionsAction = new RelayCommand(UpdateEmployeePositions, CanUpdateEmployeePositions);
            _deleteEmployeePositionsAction = new RelayCommand(DeleteEmployeePositions);
            _makeEditableAction = new RelayCommand(MakeEditable, CanMakeEditable);
            _resetChangesAction = new RelayCommand(ResetChanges, CanResetChanges);
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = _searchViewModel;
            _searchViewModel.SearchCommand.Execute(null);
        }

        private void UpdateEmployeePositions(object obj)
        {
           
            _employeePosEntity.EmployeeId = _employeePosition.EmployeeId;
            _employeePosEntity.Employee = _employeePosition.Employee;
            _employeePosEntity.PositionId = _employeePosition.PositionId;
            _employeePosEntity.Position = _employeePosition.Position;
            _employeePosEntity.ProjectId = _employeePosition.ProjectId;
            _employeePosEntity.Project = _employeePosition.Project;

            _employeePosEntity.StartDate = _employeePosition.StartDate;
            _employeePosEntity.EndDate = _employeePosition.EndDate;

            _employeePosService.UpdateEmployeePositions(_employeePosEntity);//.UpdateProject(_projectEntity);
            IsEditable = false;
        }

        private bool CanUpdateEmployeePositions(object obj)
        {
            if (_employeePosition.EmployeeId < 0)
            {
                ErrorMessage = "EmployeeId name can't be less than 0";
                return false;
            }
            if (String.IsNullOrEmpty(_employeePosition.Employee.FirstName))
            {
                ErrorMessage = "FirstName can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(_employeePosition.Employee.LastName))
            {
                ErrorMessage = "LastName can't be empty";
                return false;
            }
            if (_employeePosition.PositionId < 0)
            {
                ErrorMessage = "PositionId name can't be less than 0";
                return false;
            }
            if (String.IsNullOrEmpty(_employeePosition.Position.Name))
            {
                ErrorMessage = "Position name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(_employeePosition.Position.Description))
            {
                ErrorMessage = "Position description can't be empty";
                return false;
            }
            if (_employeePosition.ProjectId < 0)
            {
                ErrorMessage = "ProjectId can't be less than 0";
                return false;
            }

            return true;
        }

        private void DeleteEmployeePositions(object obj)
        {
            _employeePosService.DeleteEmployeePositions(_employeePosEntity);
            Back(null);
        }

        private void ResetChanges(object obj)
        {
            EmployeePos = new EmployeePositionViewModel(_employeePosEntity);
        }

        private bool CanResetChanges(object obj) => _isEditable;

        private void MakeEditable(object obj)
        {
            IsEditable = true;
        }
        private bool CanMakeEditable(object obj) => !_isEditable;

        private NavigationViewModel _navigationViewModel;


        private EmployeePositionViewModel _employeePosition;
        public EmployeePositionViewModel EmployeePos
        {
            get { return _employeePosition; }
            //?
            set { _employeePosition = value; OnPoropertyChanged("Project"); }
        }

        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPoropertyChanged("ErrorMessage"); }
        }
        private bool _isEditable = false;
        public Boolean IsEditable
        {
            get { return _isEditable; }
            set { _isEditable = value; OnPoropertyChanged("IsEditable"); ButtonChange(); }
        }

        private void ButtonChange()
        {
            OnPoropertyChanged("FirstButtonText");
            OnPoropertyChanged("SecondButtonText");
            OnPoropertyChanged("FirstButtonAction");
            OnPoropertyChanged("SecondButtonAction");
        }
    }
}

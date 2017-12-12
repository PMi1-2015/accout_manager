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
    public class EmployeeUpdateViewModel : BaseViewModel
    {
        private EmployeesViewModel _searchViewModel;

        public String FirstButtonText => IsEditable ? "Save Changes" : "Update";
        public String SecondButtonText => IsEditable ? "Reset" : "Delete";

        public ICommand FirstButtonAction => IsEditable ? UpdateEmployeeAction : MakeEditableAction;
        public ICommand SecondButtonAction => IsEditable ? ResetChangesAction : DeleteEmployeeAction;

        private Employee _employeeEntity;
        private IEmployeeService _employeeService;

        public ICommand BackAction { get; set; }

        private ICommand _updateEmployeeAction;
        public ICommand UpdateEmployeeAction => _updateEmployeeAction;

        private ICommand _deleteEmployeeAction;
        public ICommand DeleteEmployeeAction => _deleteEmployeeAction;

        private ICommand _resetChangesAction;
        public ICommand ResetChangesAction => _resetChangesAction;

        private ICommand _makeEditableAction;
        public ICommand MakeEditableAction => _makeEditableAction;

        public EmployeeUpdateViewModel(NavigationViewModel navigationViewModel, EmployeesViewModel searchModel, Employee employee)
        {
            _searchViewModel = searchModel;
            _employeeEntity = employee;
            _employee = new EmployeeViewModel(employee);

            _navigationViewModel = navigationViewModel;
            _employeeService = ServiceLocator.Instance.GetService<IEmployeeService>();

            BackAction = new RelayCommand(Back);

            _updateEmployeeAction = new RelayCommand(UpdateEmployee, CanUpdateEmployee);
            _deleteEmployeeAction = new RelayCommand(DeleteEmployee);
            _makeEditableAction = new RelayCommand(MakeEditable, CanMakeEditable);
            _resetChangesAction = new RelayCommand(ResetChanges, CanResetChanges);
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = _searchViewModel;
            _searchViewModel.SearchCommand.Execute(null);
        }

        private void UpdateEmployee(object obj)
        {
            _employeeEntity.FirstName = _employee.EmployeeFirstName;
            _employeeEntity.LastName = _employee.EmployeeLastName;

            _employeeService.UpdateEmployee(_employeeEntity);
            IsEditable = false;
        }

        private bool CanUpdateEmployee(object obj)
        {
            if (String.IsNullOrEmpty(_employee.EmployeeFirstName))
            {
                ErrorMessage = "Employee first name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(_employee.EmployeeLastName))
            {
                ErrorMessage = "Employee last name can't be empty";
                return false;
            }

            return true;
        }

        private void DeleteEmployee(object obj)
        {
            _employeeService.DeleteEmployee(_employeeEntity);
            Back(null);
        }

        private void ResetChanges(object obj)
        {
            Employee = new EmployeeViewModel(_employeeEntity);
        }

        private bool CanResetChanges(object obj) => _isEditable;

        private void MakeEditable(object obj)
        {
            IsEditable = true;
        }
        private bool CanMakeEditable(object obj) => !_isEditable;

        private NavigationViewModel _navigationViewModel;


        private EmployeeViewModel _employee;
        public EmployeeViewModel Employee
        {
            get { return _employee; }
            set { _employee = value; OnPoropertyChanged("Employee"); }
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

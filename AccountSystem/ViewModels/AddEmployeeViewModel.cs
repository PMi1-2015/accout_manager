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
    public class AddEmployeeViewModel: BaseViewModel
    {
        private IEmployeeService _employeeService;

        public ICommand BackAction { get; set; }

        private ICommand _saveEmployeeAction;
        public ICommand SaveEmployeeAction { get { return _saveEmployeeAction; } }

        public AddEmployeeViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _employeeService = ServiceLocator.Instance.GetService<IEmployeeService>();

            BackAction = new RelayCommand(Back);
            _saveEmployeeAction = new RelayCommand(SaveEmployee, CanSaveEmployee);
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeesCrudViewModel(_navigationViewModel);
        }

        private void SaveEmployee(object obj)
        {
            Employee employee = new Employee
            {
                FirstName = this.EmployeeFirstName,
                LastName = this.EmployeeLastName
            };

            _employeeService.SaveEmployee(employee);
            BackAction?.Execute(null);
        }

        private bool CanSaveEmployee(object obj)
        {
            if (String.IsNullOrEmpty(EmployeeFirstName))
            {
                ErrorMessage = "Employee first name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(EmployeeLastName))
            {
                ErrorMessage = "Employee last name can't be empty";
                return false;
            }
            return true;
        }

        private NavigationViewModel _navigationViewModel;

        private String _employeeFirstName;
        public String EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; OnPoropertyChanged("EmployeeFirstName"); }
        }

        private String _employeeLastName;
        public String EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; OnPoropertyChanged("EmployeeLastName"); }
        }

        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPoropertyChanged("ErrorMessage"); }
        }
    }
}

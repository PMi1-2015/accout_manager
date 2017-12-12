using AccountSystem.Data.models;
using AccountSystem.Services;
using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        public Employee SelectedEmployee { get; set; }

        private IEmployeeService _employeeService;
        private NavigationViewModel _navigationViewModel;

        private List<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return new ObservableCollection<Employee>(_employees);
            }
            set
            {
                _employees = value.ToList();
                OnPoropertyChanged("Employees");
            }
        }

        private String _searchName;
        public String SearchName
        {
            get { return _searchName; }
            set
            {
                _searchName = value;
                OnPoropertyChanged("SearchName");
            }
        }

        public ICommand BackAction { get; set; }

        private ICommand _selectEmployeeAction;
        public ICommand SelectEmployeeAction => _selectEmployeeAction;

        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand;

        public void SelectEmployee(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeeUpdateViewModel(_navigationViewModel, this, SelectedEmployee);
        }

        public EmployeesViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _employeeService = ServiceLocator.Instance.GetService<IEmployeeService>();

            _employees = new List<Employee>();

            _searchCommand = new RelayCommand(e =>
            {
                Employees = new ObservableCollection<Employee>(SearchEmployees());
            });

            BackAction = new RelayCommand(ReturnBack);

            _selectEmployeeAction = new RelayCommand(SelectEmployee);
        }

        private List<Employee> SearchEmployees()
        {
            return _employeeService.SearchEmployee(SearchName);
        }

        private void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeesCrudViewModel(_navigationViewModel);
        }
    }
}

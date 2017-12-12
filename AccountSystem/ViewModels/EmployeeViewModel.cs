using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public EmployeeViewModel()
        {

        }

        public EmployeeViewModel(Employee employee)
        {
            _employeeFirstName = employee.FirstName;
            _employeeLastName = employee.LastName;
        }


        private String _employeeFirstName;
        public String EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; OnPropertyChanged("EmployeeFirstName"); }
        }
        private String _employeeLastName;
        public String EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; OnPropertyChanged("EmployeeLastName"); }
        }
    }
}

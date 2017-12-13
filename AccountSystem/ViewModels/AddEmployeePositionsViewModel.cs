using AccountSystem.Data.models;
using AccountSystem.Services;
using AccountSystem.Utilities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class AddEmployeePositionsViewModel : BaseViewModel
    {
        private IEmployeePositionsService _EmployeePositionsService;

        public ICommand BackAction { get; set; }

        private ICommand _saveEmployeePositionsAction;
        public ICommand SaveEmployeePositionsAction { get { return _saveEmployeePositionsAction; } }
        private NavigationViewModel _navigationViewModel;
        private long _employeeId;
        public long EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; OnPoropertyChanged("EmployeeId"); }
        }

        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set { _employee = value; OnPoropertyChanged("Employee"); }
        }

        private long _positionId;
        public long PositionId
        {
            get { return _positionId; }
            set { _positionId = value; OnPoropertyChanged("PositionId"); }
        }

        private Position _position;
        public Position Position
        {
            get { return _position; }
            set { _position = value; OnPoropertyChanged("Position"); }
        }


        private long _projectId;
        public long ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; OnPoropertyChanged("ProjectId"); }
        }


        private Project _project;
        public Project Project
        {
            get { return _project; }
            set { _project = value; OnPoropertyChanged("Project"); }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPoropertyChanged("StartDate"); }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPoropertyChanged("EndDate"); }
        }


        public AddEmployeePositionsViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _EmployeePositionsService = ServiceLocator.Instance.GetService<IEmployeePositionsService>();

            BackAction = new RelayCommand(Back);
            _saveEmployeePositionsAction = new RelayCommand(SaveEmployeePositions, CanSaveSaveEmployeePositions);

            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = new ProjectsCrudViewModel(_navigationViewModel);
        }

        private void SaveEmployeePositions(object obj)
        {
            EmployeePosition pos = new EmployeePosition
            {
                EmployeeId = this.EmployeeId,
                Employee = this.Employee,
                PositionId = this.PositionId,
                Position = this.Position,
                ProjectId = this.ProjectId,
                Project = this.Project,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };

            _EmployeePositionsService.SaveEmployeePositions(pos);
            BackAction?.Execute(null);
        }

        private bool CanSaveSaveEmployeePositions(object obj)
        {
            if (EmployeeId < 0)
            {
                ErrorMessage = "EmployeeId name can't be less than 0";
                return false;
            }
            if (String.IsNullOrEmpty(Employee.FirstName))
            {
                ErrorMessage = "FirstName can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(Employee.LastName))
            {
                ErrorMessage = "LastName can't be empty";
                return false;
            }
            if (PositionId < 0)
            {
                ErrorMessage = "PositionId name can't be less than 0";
                return false;
            }
            if (String.IsNullOrEmpty(Position.Name))
            {
                ErrorMessage = "Position name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(Position.Description))
            {
                ErrorMessage = "Position description can't be empty";
                return false;
            }
            if (ProjectId < 0 )
            {
                ErrorMessage = "ProjectId can't be less than 0";
                return false;
            }
            if (String.IsNullOrEmpty(Project.Name))
            {
                ErrorMessage = "Project name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(Project.Description))
            {
                ErrorMessage = "Project description can't be empty";
                return false;
            }
            if (StartDate == null || StartDate.CompareTo(EndDate) > 0)
            {
                ErrorMessage = "Invalid project period";
                return false;
            }

            return true;
        }
        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPoropertyChanged("ErrorMessage"); }
        }
    }
}

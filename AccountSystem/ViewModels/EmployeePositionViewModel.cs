using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.ViewModels
{
    class EmployeePositionViewModel : BaseViewModel
    {
        public EmployeePositionViewModel()
        {

        }

        public EmployeePositionViewModel(EmployeePosition pos)
        {
            EmployeeId = pos.EmployeeId;
            Employee = pos.Employee;
            PositionId = pos.PositionId;
            Position = pos.Position;
            ProjectId = pos.ProjectId;
            Project = pos.Project;
            StartDate = pos.StartDate;
            EndDate = pos.EndDate;
        }


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

    }
}

using AccountSystem.Data.models;
using AccountSystem.Services;
using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    class EmployeePositionsViewModel : BaseViewModel
    {
        public EmployeePosition SelectedPos { get; set; }

        private bool _useStart = false;
        //?
        public Boolean UseStart { get { return _useStart; } set { _useStart = value; OnPoropertyChanged("UseStart"); } }

        private bool _useEnd = false;
        //?
        public Boolean UseEnd { get { return _useEnd; } set { _useEnd = value; OnPoropertyChanged("UseEnd"); } }

        private IEmployeePositionsService _posService;
        private NavigationViewModel _navigationViewModel;

        private List<EmployeePosition> _positions;
        public ObservableCollection<EmployeePosition> Positions
        {
            get
            {
                return new ObservableCollection<EmployeePosition>(_positions);
            }
            set
            {
                _positions = value.ToList();
                OnPoropertyChanged("EmployeePositions");
            }
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


        private DateTime? _start = DateTime.Now;
        public DateTime? StartDate
        {
            get
            {
                return _start == null ? DateTime.Now : _start;
            }
            set
            {
                _start = value;
                OnPoropertyChanged("StartDate");
            }
        }

        private DateTime? _end = DateTime.Now;
        public DateTime? EndDate
        {
            get
            {
                return _end == null ? DateTime.Now : _end;
            }
            set
            {
                _end = value;

                OnPoropertyChanged("EndDate");
            }
        }


        public ICommand BackAction { get; set; }

        private ICommand _EmployeePositionsAction;
        public ICommand SelectEmployeePositionsAction => _EmployeePositionsAction;

        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand;

        public void SelectEmployeePosition(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeePositionsUpdateViewModel(_navigationViewModel, this, SelectedPos);
        }

        public EmployeePositionsViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _posService = ServiceLocator.Instance.GetService<IEmployeePositionsService>();

            _positions = new List<EmployeePosition>();

            _searchCommand = new RelayCommand(e =>
            {
                Positions = new ObservableCollection<EmployeePosition>(SearchEmployeePositionsByProjectId());
            });

            BackAction = new RelayCommand(ReturnBack);

            _EmployeePositionsAction = new RelayCommand(SelectEmployeePosition);
        }

        //private List<EmployeePosition> SearchEmployeePositionsByEmployeeId()
        //{
        //    return _posService.FindByEmployeeId(PositionId);
        //    //return _posService.FindByEmployeeId()
        //    //.SearchProject(SearchName, _useStart ? StartDate : null, _useEnd ? EndDate : null);
        //}

        private List<EmployeePosition> SearchEmployeePositionsByProjectId()
        {
            return _posService.FindByProjectId(ProjectId);
            //return _posService.FindByEmployeeId()
            //.SearchProject(SearchName, _useStart ? StartDate : null, _useEnd ? EndDate : null);
        }

        private void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeePositionsCrudViewModel(_navigationViewModel);
        }
    }
}

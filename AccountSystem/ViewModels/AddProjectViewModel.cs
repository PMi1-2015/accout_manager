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
    public class AddProjectViewModel : BaseViewModel
    {
        private IProjectService _projectService;

        public ICommand BackAction { get; set; }

        private ICommand _saveProjecAction;
        public ICommand SaveProjectAction { get { return _saveProjecAction; } }

        public AddProjectViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _projectService = ServiceLocator.Instance.GetService<IProjectService>();

            BackAction = new RelayCommand(Back);
            _saveProjecAction = new RelayCommand(SaveProject, CanSaveProject);

            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = new ProjectsCrudViewModel(_navigationViewModel);
        }

        private void SaveProject(object obj)
        {
            Project project = new Project
            {
                Name = this.ProjectName,
                Description = this.ProjectDescription,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };

            _projectService.SaveProject(project);
            BackAction?.Execute(null);
        }

        private bool CanSaveProject(object obj)
        {
            if (String.IsNullOrEmpty(ProjectName))
            {
                ErrorMessage = "Project name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(ProjectDescription))
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

        private NavigationViewModel _navigationViewModel;

        private String _projectName;
        public String ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; OnPoropertyChanged("ProjectName"); }
        }

        private String _projecDescription;
        public String ProjectDescription
        {
            get { return _projecDescription; }
            set { _projecDescription = value; OnPoropertyChanged("ProjectDescription"); }
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

        private String _errorMessage;
        public String ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPoropertyChanged("ErrorMessage"); }
        }
    }
}

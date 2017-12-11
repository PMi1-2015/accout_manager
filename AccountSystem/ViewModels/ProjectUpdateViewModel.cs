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
    class ProjectUpdateViewModel : BaseViewModel
    {
        private ProjectsViewModel _searchViewModel;

        public String FirstButtonText => IsEditable ? "Save Changes" : "Update";
        public String SecondButtonText => IsEditable ? "Reset" : "Delete";

        public ICommand FirstButtonAction => IsEditable ? UpdateProjectAction : MakeEditableAction;
        public ICommand SecondButtonAction => IsEditable ? ResetChangesAction : DeleteProjectAction;

        private Project _projectEntity;
        private IProjectService _projectService;

        public ICommand BackAction { get; set; }

        private ICommand _updateProjectAction;
        public ICommand UpdateProjectAction => _updateProjectAction;

        private ICommand _deleteProjectAction;
        public ICommand DeleteProjectAction => _deleteProjectAction;

        private ICommand _resetChangesAction;
        public ICommand ResetChangesAction => _resetChangesAction;

        private ICommand _makeEditableAction;
        public ICommand MakeEditableAction => _makeEditableAction;

        public ProjectUpdateViewModel(NavigationViewModel navigationViewModel, ProjectsViewModel searchModel, Project project)
        {
            _searchViewModel = searchModel;
            _projectEntity = project;
            _project = new ProjectViewModel(project);

            _navigationViewModel = navigationViewModel;
            _projectService = ServiceLocator.Instance.GetService<IProjectService>();

            BackAction = new RelayCommand(Back);

            _updateProjectAction = new RelayCommand(UpdateProject, CanUpdateProject);
            _deleteProjectAction = new RelayCommand(DeleteProject);
            _makeEditableAction = new RelayCommand(MakeEditable, CanMakeEditable);
            _resetChangesAction = new RelayCommand(ResetChanges, CanResetChanges);
        }

        private void Back(object obj)
        {
            _navigationViewModel.SelectedViewModel = _searchViewModel;
            _searchViewModel.SearchCommand.Execute(null);
        }

        private void UpdateProject(object obj)
        {
            _projectEntity.Name = _project.ProjectName;
            _projectEntity.Description = _project.ProjectDescription;
            _projectEntity.StartDate = _project.StartDate;
            _projectEntity.EndDate = _project.EndDate;

            _projectService.UpdateProject(_projectEntity);
            IsEditable = false;
        }

        private bool CanUpdateProject(object obj)
        {
            if (String.IsNullOrEmpty(_project.ProjectName))
            {
                ErrorMessage = "Project name can't be empty";
                return false;
            }
            if (String.IsNullOrEmpty(_project.ProjectDescription))
            {
                ErrorMessage = "Project description can't be empty";
                return false;
            }
            if (_project.StartDate == null || _project.StartDate.CompareTo(_project.EndDate) > 0)
            {
                ErrorMessage = "Invalid project period";
                return false;
            }

            return true;
        }

        private void DeleteProject(object obj)
        {
            _projectService.DeleteProject(_projectEntity);
            Back(null);
        }

        private void ResetChanges(object obj)
        {
            Project = new ProjectViewModel(_projectEntity);
        }

        private bool CanResetChanges(object obj) => _isEditable;

        private void MakeEditable(object obj)
        {
            IsEditable = true;
        }
        private bool CanMakeEditable(object obj) => !_isEditable;

        private NavigationViewModel _navigationViewModel;


        private ProjectViewModel _project;
        public ProjectViewModel Project
        {
            get { return _project; }
            set { _project = value; OnPropertyChanged("Project"); }
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

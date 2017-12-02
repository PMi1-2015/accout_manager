﻿using AccountSystem.Data.models;
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
    class ProjectsViewModel : BaseViewModel
    {
        private bool _useStart = false;
        public Boolean UseStart { get { return _useStart; } set { _useStart = value; OnPoropertyChanged("UseStart"); } }

        private bool _useEnd = false;
        public Boolean UseEnd { get { return _useEnd; } set { _useEnd = value; OnPoropertyChanged("UseEnd"); } }

        private IProjectService _projectService;
        private NavigationViewModel _navigationViewModel;

        private List<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(_projects);
            }
            set
            {
                _projects = value.ToList();
                OnPoropertyChanged("Projects");
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

        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand;

        public ProjectsViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _projectService = ServiceLocator.Instance.GetService<IProjectService>();

            _projects = new List<Project>();

            _searchCommand = new RelayCommand(e =>
            {
                Projects = new ObservableCollection<Project>(SearchProjects());
            });

            BackAction = new RelayCommand(ReturnBack);
        }

        private List<Project> SearchProjects()
        {
            return _projectService.SearchProject(SearchName, _useStart ? StartDate : null, _useEnd ? EndDate : null);
        }

        private void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new ProjectsCrudViewModel(_navigationViewModel);
        }
    }
}

using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class MenuViewModel: BaseViewModel
    {
        public ICommand ProjectsCommand { get; set; }
		
        public ICommand EmployeeCommand { get; set; }
		
        public ICommand PositionsCommand { get; set; }

        private NavigationViewModel _navigationViewModel;

        public MenuViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;

            ProjectsCommand = new RelayCommand(GoToProjectsControl);
			
            EmployeeCommand = new RelayCommand(GoToEmployeesControl);
			
            PositionsCommand = new RelayCommand(GoToPositionsControl);
        }

        private void GoToProjectsControl(object obj)
        {
            _navigationViewModel.SelectedViewModel = new ProjectsCrudViewModel(_navigationViewModel);
        }
		
        private void GoToEmployeesControl(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeesCrudViewModel(_navigationViewModel);
		}

        private void GoToPositionsControl(object obj)
        {
            _navigationViewModel.SelectedViewModel = new PositionsCrudViewModel(_navigationViewModel);
        }
    }
}

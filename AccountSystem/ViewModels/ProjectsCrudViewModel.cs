using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class ProjectsCrudViewModel: BaseViewModel
    {
        private NavigationViewModel _navigationViewModel;

        public ICommand BackAction { get; set; }
        public ICommand AddProjectViewAction { get; set; }

        public ProjectsCrudViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;

            BackAction = new RelayCommand(ReturnBack);
            AddProjectViewAction = new RelayCommand(AddProjectView);
        }

        public void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new MenuViewModel(_navigationViewModel);
        }

        public void AddProjectView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new AddProjectViewModel(_navigationViewModel);
        }
    }
}

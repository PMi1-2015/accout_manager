using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class EmployeePositionsCrudViewModel: BaseViewModel
    {
        private NavigationViewModel _navigationViewModel;

        public ICommand BackAction { get; set; }
        public ICommand AddEmployeePositionsViewAction { get; set; }
        public ICommand FindEmployeePositionsViewAction { get; set; }

        public EmployeePositionsCrudViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;

            BackAction = new RelayCommand(ReturnBack);
            AddEmployeePositionsViewAction = new RelayCommand(AddEmployeePositionsView);
            FindEmployeePositionsViewAction = new RelayCommand(FindEmployeePositionsView);
        }

        public void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new MenuViewModel(_navigationViewModel);
        }

        public void AddEmployeePositionsView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new AddEmployeePositionsViewModel(_navigationViewModel);
        }

        public void FindEmployeePositionsView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeePositionsViewModel(_navigationViewModel);
        }
    }
}

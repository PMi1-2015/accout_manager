using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class EmployeesCrudViewModel : BaseViewModel
    {
        private NavigationViewModel _navigationViewModel;

        public ICommand BackAction { get; set; }
        public ICommand AddEmployeeViewAction { get; set; }
        public ICommand FindEmployeeViewAction { get; set; }

        public EmployeesCrudViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;

            BackAction = new RelayCommand(ReturnBack);
            AddEmployeeViewAction = new RelayCommand(AddEmployeeView);
            FindEmployeeViewAction = new RelayCommand(FindEmployeeView);
        }

        public void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new MenuViewModel(_navigationViewModel);
        }

        public void AddEmployeeView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new AddEmployeeViewModel(_navigationViewModel);
        }

        public void FindEmployeeView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new EmployeesViewModel(_navigationViewModel);
        }
    }
}

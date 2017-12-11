using AccountSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountSystem.ViewModels
{
    public class PositionsCrudViewModel : BaseViewModel
    {
        private NavigationViewModel _navigationViewModel;

        public ICommand BackAction { get; set; }
        public ICommand AddPositionViewAction { get; set; }
        public ICommand FindPositionViewAction { get; set; }

        public PositionsCrudViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;

            BackAction = new RelayCommand(ReturnBack);
            AddPositionViewAction = new RelayCommand(AddPositionView);
            FindPositionViewAction = new RelayCommand(FindPositionView);
        }

        public void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new MenuViewModel(_navigationViewModel);
        }

        public void AddPositionView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new AddPositionViewModel(_navigationViewModel);
        }

        public void FindPositionView(object obj)
        {
            _navigationViewModel.SelectedViewModel = new PositionsViewModel(_navigationViewModel);
        }
    }
}

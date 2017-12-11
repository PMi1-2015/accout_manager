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
    class PositionsViewModel : BaseViewModel
    {
        public Position SelectedPosition { get; set; }

        private bool _useStart = false;
        public Boolean UseStart { get { return _useStart; } set { _useStart = value; OnPoropertyChanged("UseStart"); } }

        private bool _useEnd = false;
        public Boolean UseEnd { get { return _useEnd; } set { _useEnd = value; OnPoropertyChanged("UseEnd"); } }

        private IPositionService _positionService;
        private NavigationViewModel _navigationViewModel;

        private List<Position> _positions;
        public ObservableCollection<Position> Positions
        {
            get
            {
                return new ObservableCollection<Position>(_positions);
            }
            set
            {
                _positions = value.ToList();
                OnPoropertyChanged("Positions");
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

        public ICommand BackAction { get; set; }

        private ICommand _selectPositionAction;
        public ICommand SelectPositionAction => _selectPositionAction;

        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand;

        public void SelectPosition(object obj)
        {
            _navigationViewModel.SelectedViewModel = new PositionUpdateViewModel(_navigationViewModel, this, SelectedPosition);
        }

        public PositionsViewModel(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _positionService = ServiceLocator.Instance.GetService<IPositionService>();

            _positions = new List<Position>();

            _searchCommand = new RelayCommand(e =>
            {
                Positions = new ObservableCollection<Position>(SearchPositions());
            });

            BackAction = new RelayCommand(ReturnBack);

            _selectPositionAction = new RelayCommand(SelectPosition);
        }

        private List<Position> SearchPositions()
        {
            return _positionService.SearchPosition(SearchName);
        }

        private void ReturnBack(object obj)
        {
            _navigationViewModel.SelectedViewModel = new PositionsCrudViewModel(_navigationViewModel);
        }
    }
}

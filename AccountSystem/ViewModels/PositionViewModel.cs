using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.ViewModels
{
    class PositionViewModel : BaseViewModel
    {
        public PositionViewModel()
        {

        }

        public PositionViewModel(Position position)
        {
            _positionName = position.Name;
            _positionDescription = position.Description;
        }
        
        private String _positionName;
        public String PositionName
        {
            get { return _positionName; }
            set { _positionName = value; OnPropertyChanged("PositionName"); }
        }

        private String _positionDescription;
        public String PositionDescription
        {
            get { return _positionDescription; }
            set { _positionDescription = value; OnPropertyChanged("PositionDescription"); }
        }
        
    }
}

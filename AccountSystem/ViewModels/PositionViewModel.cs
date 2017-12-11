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
            _projecDescription = position.Description;
        }


        private String _positionName;
        public String PositionName
        {
            get { return _positionName; }
            set { _positionName = value; OnPoropertyChanged("PositionName"); }
        }

        private String _projecDescription;
        public String PositionDescription
        {
            get { return _projecDescription; }
            set { _projecDescription = value; OnPoropertyChanged("PositionDescription"); }
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

    }
}

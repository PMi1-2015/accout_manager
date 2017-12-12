using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.ViewModels
{
    class ProjectViewModel: BaseViewModel
    {
        public ProjectViewModel()
        {

        }

        public ProjectViewModel(Project project)
        {
            _projectName = project.Name;
            _projectDescription = project.Description;
            _startDate = project.StartDate;
            _endDate = project.EndDate;
        }

        private String _projectName;
        public String ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; OnPropertyChanged("ProjectName"); }
        }

        private String _projectDescription;
        public String ProjectDescription
        {
            get { return _projectDescription; }
            set { _projectDescription = value; OnPropertyChanged("ProjectDescription"); }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged("StartDate"); }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged("EndDate"); }
        }
        
    }
}

using AccountSystem.Data;
using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services.impl
{
    class ProjectService: IProjectService
    {
        private IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveProject(Project project)
        {
            ValidateProject(project);

            _unitOfWork.ProjectRepository.Add(project);
            _unitOfWork.Save();
        }

        public List<Project> SearchProject(string name, DateTime? startDate, DateTime? endDate)
        {
            return _unitOfWork.ProjectRepository.SearchProject(name, startDate, endDate).ToList();
        }

        private void ValidateProject(Project project)
        {
            if (project.StartDate.CompareTo(project.EndDate) > 0 ||
                project.Name.Length == 0 || project.Description.Length == 0)
            {
                throw new Exception("Invalid project data");
            }
        }


    }
}

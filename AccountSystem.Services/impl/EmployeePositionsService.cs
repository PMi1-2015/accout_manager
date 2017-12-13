using AccountSystem.Data;
using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services.impl
{
    class EmployeePositionsService : IEmployeePositionsService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeePositionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteEmployeePositions(EmployeePosition pos)
        {
            _unitOfWork.EmployeePositionRepository.Delete(pos.Id);
            _unitOfWork.Save();
        }

        public List<EmployeePosition> FindByEmployeeId(long id)
        {
            return _unitOfWork.EmployeePositionRepository.FindByEmployeeId(id).ToList();
        }

        public List<EmployeePosition> FindByProjectId(long id)
        {
            return _unitOfWork.EmployeePositionRepository.FindByProjectId(id).ToList();
        }

        public void SaveEmployeePositions(EmployeePosition pos)
        {
            ValidateProject(pos);

            _unitOfWork.EmployeePositionRepository.Add(pos);
            _unitOfWork.Save();
        }

        public void UpdateEmployeePositions(EmployeePosition pos)
        {
            ValidateProject(pos);

            _unitOfWork.EmployeePositionRepository.Update(pos);
            _unitOfWork.Save();
        }


        private void ValidateProject(EmployeePosition pos)
        {
            if (pos.StartDate.CompareTo(pos.EndDate) > 0 ||
                pos.EmployeeId == 0 || pos.PositionId == 0 || pos.ProjectId == 0)
            {
                throw new Exception("Invalid project data");
            }
        }
    }
}

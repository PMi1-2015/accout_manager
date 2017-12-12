using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSystem.Data.models;
using AccountSystem.Data;

namespace AccountSystem.Services.impl
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee.Id);
            _unitOfWork.Save();
        }

        public void SaveEmployee(Employee employee)
        {
            ValidateEmployee(employee);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Save();
        }

        public List<Employee> SearchEmployee(string name)
        {
            return _unitOfWork.EmployeeRepository.FindByName(name).ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            ValidateEmployee(employee);

            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Save();
        }
        private void ValidateEmployee(Employee employee)
        {
            if (employee.FirstName.Length == 0 || employee.LastName.Length == 0)
            {
                throw new Exception("Invalid project data");
            }
        }
    }
}

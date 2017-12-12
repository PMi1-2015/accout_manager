using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services
{
    public interface IEmployeeService
    {
        void SaveEmployee(Employee project);

        void UpdateEmployee(Employee project);

        void DeleteEmployee(Employee project);

        List<Employee> SearchEmployee(String name);
    }
}

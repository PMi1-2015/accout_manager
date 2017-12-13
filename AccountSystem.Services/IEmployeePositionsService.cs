using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Services
{
    public interface IEmployeePositionsService
    {
        void SaveEmployeePositions(EmployeePosition pos);

        void UpdateEmployeePositions(EmployeePosition pos);

        void DeleteEmployeePositions(EmployeePosition pos);

        List<EmployeePosition> FindByEmployeeId(long id);
        List<EmployeePosition> FindByProjectId(long id);
    }
}

using AccountSystem.Data.models;
using System.Collections.Generic;

namespace AccountSystem.Data
{
    public interface IEmployeePositionRepository: IRepository<EmployeePosition>
    {
        IEnumerable<EmployeePosition> FindByEmployeeId(long id);

        IEnumerable<EmployeePosition> FindByProjectId(long id);
    }
}

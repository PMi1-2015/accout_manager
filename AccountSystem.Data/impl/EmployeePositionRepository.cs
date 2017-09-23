using System.Collections.Generic;
using AccountSystem.Data.models;
using System.Linq;

namespace AccountSystem.Data.impl
{
    class EmployeePositionRepository :
        GenericRepository<EmployeePosition>,
        IEmployeePositionRepository
    {
        public EmployeePositionRepository(AccountSystemContext context) : base(context) { }

        public IEnumerable<EmployeePosition> FindByEmployeeId(long id)
        {
            return _dbSet.Where(ep => ep.EmployeeId == id).ToList();
        }

        public IEnumerable<EmployeePosition> FindByProjectId(long id)
        {
            return _dbSet.Where(ep => ep.ProjectId == id).ToList();
        }
    }
}

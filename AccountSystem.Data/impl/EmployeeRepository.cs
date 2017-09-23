using AccountSystem.Data.models;
using System.Collections.Generic;
using System.Linq;

namespace AccountSystem.Data.impl
{
    class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AccountSystemContext context) : base(context) { }

        public IEnumerable<Employee> FindByName(string name)
        {
            name = name.Trim().ToLower();

            return _dbSet.Where(empl => (empl.FirstName + " " + empl.LastName).Trim().ToLower().Contains(name)).ToList();
        }
    }
}

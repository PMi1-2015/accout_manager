using System;
using System.Collections.Generic;
using AccountSystem.Data.models;
using System.Linq;
using System.Data.Entity;

namespace AccountSystem.Data.impl
{
    class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AccountSystemContext context) : base(context) { }

        public IEnumerable<Project> SearchProject(string name, DateTime? startDate, DateTime? endDate)
        {
            return _dbSet.Where(pr => pr.Name.ToLower().Contains(name.ToLower()) && (startDate == null || DbFunctions.TruncateTime(pr.StartDate) >= DbFunctions.TruncateTime(startDate))
                    && (endDate == null || DbFunctions.TruncateTime(pr.EndDate) <= DbFunctions.TruncateTime(endDate)));
        }
    }
}

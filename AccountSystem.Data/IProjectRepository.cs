using AccountSystem.Data.models;
using System;
using System.Collections.Generic;

namespace AccountSystem.Data
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> SearchProject(String name, DateTime? startDate, DateTime? endDate);
    }
}

using AccountSystem.Data.models;
using System;
using System.Collections.Generic;
namespace AccountSystem.Data
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee >FindByName(String name);
    }
}

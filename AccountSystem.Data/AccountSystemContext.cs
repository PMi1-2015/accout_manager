using AccountSystem.Data.models;
using System.Data.Entity;

namespace AccountSystem.Data
{
    class AccountSystemContext : DbContext
    {
        private static readonly string DATABASE_CONNECTION_STRING_NAME = "AccountSystemDatabase";

        public AccountSystemContext() : base(DATABASE_CONNECTION_STRING_NAME) { }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<EmployeePosition> EmployeePositions { get; set; }
    }
}

namespace AccountSystem.Data
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        IProjectRepository ProjectRepository { get; }

        IPositionRepository PositionRepository { get; }

        IEmployeePositionRepository EmployeePositionRepository { get; }

        void Save();
    }
}

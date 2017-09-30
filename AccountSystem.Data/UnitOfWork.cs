using AccountSystem.Data.impl;
using System;

namespace AccountSystem.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AccountSystemContext _context = new AccountSystemContext();

        private IAppUserRepository _appUserRepository;
        private IEmployeeRepository _employeeRepository;
        private IProjectRepository _projectRepository;
        private IPositionRepository _positionRepository;
        private IEmployeePositionRepository _employeePositionRepository;

        public IAppUserRepository AppUserRepository
        {
            get
            {
                _appUserRepository = _appUserRepository ?? new AppUserRepository(_context);

                return _appUserRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);

                return _employeeRepository;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                _projectRepository = _projectRepository ?? new ProjectRepository(_context);

                return _projectRepository;
            }
        }

        public IPositionRepository PositionRepository
        {
            get
            {
                _positionRepository = _positionRepository ?? new PositionRepository(_context);

                return _positionRepository;
            }
        }

        public IEmployeePositionRepository EmployeePositionRepository
        {
            get
            {
                _employeePositionRepository = _employeePositionRepository ?? new EmployeePositionRepository(_context);

                return _employeePositionRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

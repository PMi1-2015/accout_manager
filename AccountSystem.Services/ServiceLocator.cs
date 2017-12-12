using AccountSystem.Data;
using AccountSystem.Services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AccountSystem.Services
{
    public class ServiceLocator
    {
        private IUnityContainer _container;

        private static ServiceLocator _serviceLocator = new ServiceLocator();

        public static ServiceLocator Instance => _serviceLocator;

        private ServiceLocator()
        {
            _container = new UnityContainer();
            Bind();
        }

        private void Bind()
        {
            _container.RegisterInstance<IAppUserService>(new AppUserService(UnitOfWork.Instance));
            _container.RegisterInstance<IProjectService>(new ProjectService(UnitOfWork.Instance));
            _container.RegisterInstance<IEmployeeService>(new EmployeeService(UnitOfWork.Instance));
            _container.RegisterInstance<IPositionService>(new PositionService(UnitOfWork.Instance));
        }

        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

﻿using AccountSystem.Data;
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
        }

        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

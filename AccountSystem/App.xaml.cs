using AccountSystem.Services;
using AccountSystem.Services.impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace AccountSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer _unityContainer = new UnityContainer();
        public UnityContainer Container { get { return _unityContainer; } }

        private void SetUpContainer()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;

            _unityContainer.RegisterInstance<IAppUserService>(serviceLocator.GetService<IAppUserService>());
            _unityContainer.RegisterInstance<IProjectService>(serviceLocator.GetService<IProjectService>());

            _unityContainer.RegisterType<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetUpContainer();

            _unityContainer.Resolve<MainWindow>().Show();
        }
    }
}

using Autofac;
using SmartHotel.Services.Dialog;
using SmartHotel.Services.Navigation;
using System;

namespace SmartHotel.ViewModels.Base
{
    public class Locator
    {
        private IContainer _container;
        private ContainerBuilder _containerBuilder;

        private static readonly Locator _instance = new Locator();
        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        public Locator()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();

            //Register viewmodel
            _containerBuilder.RegisterType<LoginViewModel>();
            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<HomeViewModel>();
            _containerBuilder.RegisterType<NotificationsViewModel>();
            _containerBuilder.RegisterType<MenuViewModel>();
        }
        public void Register<T, U>() where U : T
        {
            _containerBuilder.RegisterType<U>().As<T>();// Default create new instance

        }
        public void RegisterSingleInstance<T, U>() where U : T
        {
            _containerBuilder.RegisterType<U>().As<T>().SingleInstance();
        }
        public T Reslove<T>()
        {
            return _container.Resolve<T>();
        }
        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
        public void Build()
        {
            _container = _containerBuilder.Build();
        }
    }
}

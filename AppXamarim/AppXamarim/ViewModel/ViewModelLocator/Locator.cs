using AppXamarim.Service;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using AppXamarim.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace AppXamarim.ViewModel.ViewModelLocator
{
    public class Locator
    {
        private readonly IUnityContainer _container;
        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get { return _instance; }
        }

        public Locator()
        {
            _container = new UnityContainer();
            _container.RegisterType<IServiceMessage, ServiceMessage>();
            _container.RegisterType<IServiceNavigation, ServiceNavigation>();
            _container.RegisterType<IGetService, GetService>();

            _container.RegisterType<HomeViewModel>();
            _container.RegisterType<TabbedViewModel>();
            _container.RegisterType<TimerViewModel>();
            _container.RegisterType<AnimationViewModel>();
            _container.RegisterType<CameraViewModel>();
            _container.RegisterType<LottieAnimationViewModel>();
            _container.RegisterType<CarouselPageViewModel>();
            _container.RegisterType<ListHttpViewModel>();
            _container.RegisterType<DetailViewModel>();
            _container.RegisterType<DeviceInfoViewModel>();
            _container.RegisterType<LoginViewModel>();
            _container.RegisterType<GridViewModel>();
            _container.RegisterType<ReviewPageViewModel>();
            _container.RegisterType<LayOutViewModel>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public Object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}

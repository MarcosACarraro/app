using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppXamarim.View;
using AppXamarim.ViewModel;
using AppXamarim.ViewModel.ViewModelLocator;
using Xamarin.Forms;

namespace AppXamarim.Service.Navigation
{
    public class ServiceNavigation : IServiceNavigation
    {
        protected readonly Dictionary<Type, Type> _mapping;
        private static ServiceNavigation _instance = null;
        private static readonly object padlock = new object();

        public ServiceNavigation()
        {
            _mapping = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        public static ServiceNavigation Instance
        {
            get {
                lock(padlock)
                {
                    if (_instance == null)
                        _instance = new ServiceNavigation();
                    return _instance;
                }
               
            }
        }

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType,null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async virtual Task InternalNavigateToAsync(Type viewModelType, object parameter) {

            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainPage)
            {
                Device.BeginInvokeOnMainThread(()=>
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                });
            }
            if (page is LoginView)
            {
               CurrentApplication.MainPage = new NavigationPage(page);
            }
            else
            {
                var nav = CurrentApplication.MainPage as NavigationPage;
                Device.BeginInvokeOnMainThread(async () => {
                    await nav.PushAsync(page);
                });
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null) {
                throw new Exception($"View Model {viewModelType}  nao esta mapeado para uma page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel baseViewModel = Locator.Instance.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = baseViewModel;
            return page;
        }

        private Type GetPageTypeForViewModel(Type ViewModelType)
        {
            if (!_mapping.ContainsKey(ViewModelType))
            {
                throw new KeyNotFoundException($"Não existe mapeamento para esta view {ViewModelType}");
            }

            return _mapping[ViewModelType];
        }

        private void CreatePageViewModelMappings()
        {
            _mapping.Add(typeof(HomeViewModel), typeof(HomeView));
            _mapping.Add(typeof(TabbedViewModel), typeof(TabbedView));
            _mapping.Add(typeof(TimerViewModel), typeof(TimerView));
            _mapping.Add(typeof(AnimationViewModel), typeof(AnimationView));
            _mapping.Add(typeof(CameraViewModel), typeof(CameraView));
            _mapping.Add(typeof(LottieAnimationViewModel), typeof(LottieAnimationView));
            _mapping.Add(typeof(CarouselPageViewModel), typeof(CarouselPageView));
            _mapping.Add(typeof(ListHttpViewModel), typeof(ListHttpView));
            _mapping.Add(typeof(DetailViewModel), typeof(DetailView));
            _mapping.Add(typeof(DeviceInfoViewModel), typeof(DeviceInfoView));
            _mapping.Add(typeof(LoginViewModel), typeof(LoginView));
            _mapping.Add(typeof(GridViewModel), typeof(GridView));
            _mapping.Add(typeof(ReviewPageViewModel), typeof(ReviewPageView));
        }
    }
}

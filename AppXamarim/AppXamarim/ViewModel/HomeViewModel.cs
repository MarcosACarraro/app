using AppXamarim.Service;
using System;
using System.Collections.Generic;
using System.Text;
using DLToolkit.Forms.Controls;
using AppXamarim.Model;
using AppXamarim.Service.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using AppXamarim.Service.Message;

namespace AppXamarim.ViewModel
{
    public class HomeViewModel: BaseViewModel
    {
        MenuService _service;

        public FlowObservableCollection<MenuModel> ItensMenu { get; set; }

        IServiceNavigation _navigation;
        IServiceMessage _message;

        public HomeViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
            _service = new MenuService();
            ItensMenu = new FlowObservableCollection<MenuModel>();
            LoadItensMenu();
        }

        public ICommand ItemSelectedCommand
        {
            get {
                return new Command(async (value) => {

                    var menu = (MenuModel)value;
                    switch (menu.Id)
                    {
                        case 1: await _navigation.NavigateToAsync<LoginViewModel>();
                            break;
                        case 2:
                            await _navigation.NavigateToAsync<TabbedViewModel>();
                            break;
                        case 3:
                            await _navigation.NavigateToAsync<AnimationViewModel>();
                            break;
                        case 4:
                            await _navigation.NavigateToAsync<TimerViewModel>();
                            break;
                        case 5:
                            await _navigation.NavigateToAsync<CameraViewModel>();
                            break;
                        case 6:
                            await _navigation.NavigateToAsync<DeviceInfoViewModel>();
                            break;
                        case 7:
                            await _navigation.NavigateToAsync<LottieAnimationViewModel>();
                            break;
                        case 8:
                            await _navigation.NavigateToAsync<ListHttpViewModel>();
                            break;
                        case 9:
                            await _navigation.NavigateToAsync<CarouselPageViewModel>();
                            break;
                        case 10:
                            await _navigation.NavigateToAsync<GridViewModel>();
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        public void LoadItensMenu()
        {
            var collection = _service.GetItensMenu();

            foreach (var item in collection)
            {
                ItensMenu.Add(item);
            }
        }
    }
}

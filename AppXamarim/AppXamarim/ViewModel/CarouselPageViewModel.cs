using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.ViewModel
{
    public class CarouselPageViewModel:BaseViewModel
    {
        private IServiceNavigation _navigation;
        private IServiceMessage _message;

        public CarouselPageViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }
    }
}

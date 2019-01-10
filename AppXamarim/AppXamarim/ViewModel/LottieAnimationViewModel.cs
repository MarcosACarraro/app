using System;
using System.Collections.Generic;
using System.Text;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;

namespace AppXamarim.ViewModel
{
    public class LottieAnimationViewModel:BaseViewModel
    {
        private IServiceMessage _message;
        private IServiceNavigation _navigation;

        public LottieAnimationViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _message = message;
            _navigation = navigation;
           
        }
    }
}

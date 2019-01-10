using System;
using System.Collections.Generic;
using System.Text;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;


namespace AppXamarim.ViewModel
{
    public class AnimationViewModel:BaseViewModel
    {
        private IServiceNavigation _navigation;
        private IServiceMessage _message;

        public AnimationViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }
    }
}

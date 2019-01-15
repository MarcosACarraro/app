using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.ViewModel
{
    public class LayOutViewModel : BaseViewModel
    {
        readonly IServiceNavigation _navigation;
        readonly IServiceMessage _message;

        public LayOutViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }
    }
}

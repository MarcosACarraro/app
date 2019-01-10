using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.ViewModel
{
    public class GridViewModel : BaseViewModel
    {
        IServiceNavigation _navigation;
        IServiceMessage _message;

        public GridViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }
    }
}

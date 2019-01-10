using System;
using System.Collections.Generic;
using System.Text;
using AppXamarim.Service.Navigation;
using AppXamarim.Service.Message;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarim.ViewModel
{
    public class TimerViewModel : BaseViewModel
    {
        IServiceNavigation _navigation;
        IServiceMessage _message;

        public TimerViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }

        public ICommand StartTimerCommand
        {
            get
            {
                return new Command(() => {
                    Timer();
                });
            }
        }

        private void Timer(){
            Device.StartTimer(TimeSpan.FromSeconds(5), () => {
                _message.MsgPush("Timer Expirou!");
                //_message.Loading();
                return false;
            });
        }
    }
}

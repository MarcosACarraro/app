using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using WABRAPP.View.Messages;

namespace AppXamarim.Service.Message
{
    public class ServiceMessage:IServiceMessage
    {
        private static ServiceMessage instance = null;
        private static readonly object padlock = new object();

        public static ServiceMessage Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceMessage();
                    }
                    return instance;
                }
            }
        }

        public ServiceMessage() {
        }

        public Task CustomMessage(string message)
        {
            throw new NotImplementedException();
        }

        public async Task DisplayAlert(string message)
        {
            await Application.Current.MainPage.DisplayAlert("WABR", message, "ok");
        }

        public async Task<bool> DisplayAlertAsync(string message)
        {
            return await Application.Current.MainPage.DisplayAlert("WABR", message, "ok", "Cancelar");
        }

        public async Task Loading()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(new MessageLoading());
        }

        public  async Task MsgPush(string message)
        {
           await Application.Current.MainPage.Navigation.PushPopupAsync(new MessagePush(message));
        }
    }
}

using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarim.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        IServiceMessage _message;
        IServiceNavigation _navigation;

        public LoginViewModel(IServiceNavigation navigation ,IServiceMessage message)
        {
            _message = message;
            _navigation = navigation;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command((value) =>
                {
                    Logar();
                });
            }
        }

        public async void Logar()
        {

            await _navigation.NavigateToAsync<HomeViewModel>();

            //if (!string.IsNullOrEmpty(this.Usuario) && !string.IsNullOrEmpty(this.Senha))
            //{

            //    await _navigation.NavigateToAsync<HomeViewModel>();
            //}
            //else
            //{
            //    await _message.MsgPush("Usuario ou senha nao podem ser vazios");
            //}
        }

        #region Properties

        private string usuario = string.Empty;
        public string Usuario { get { return usuario; } set { this.Set("Usuario", ref usuario, value); } }

        private string senha = string.Empty;
        public string Senha { get { return senha; } set { this.Set("Senha", ref senha, value); } }

        #endregion
    }
}

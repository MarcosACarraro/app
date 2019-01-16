using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

            LblFollow = "33";
        }

        public ICommand BtnFollow
        {
            get
            {
                return new Command((value) =>
                {
                    OnFollow();
                });
            }
        }

        private void OnFollow() {
            int total = Int32.TryParse(LblFollow, out total) ? total : 0;
            total++;
            LblFollow = Convert.ToString(total);
        }

        #region Properties
        private string lblFollow = "";
        public string LblFollow { get { return lblFollow; } set { this.Set("LblFollow", ref lblFollow, value); } }
   
        #endregion
    }
}

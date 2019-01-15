using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarim.ViewModel
{
    public class ReviewPageViewModel: BaseViewModel
    {
        readonly IServiceNavigation _navigation;
        readonly IServiceMessage _message;

        public ReviewPageViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (!string.IsNullOrEmpty(navigationData.ToString()))
            {
                TxtResult = navigationData.ToString();
            }

            return base.InitializeAsync(navigationData);
        }


        #region Properties

        private string txtResult = string.Empty;
        public string TxtResult { get { return txtResult; } set { this.Set("TxtResult", ref txtResult, value); } }

        #endregion
    }
}

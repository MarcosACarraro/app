using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace WABRAPP.View.Messages
{
    public partial class MessageLoading : PopupPage
    {
        public MessageLoading()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HidePopup();
        }
        private async void HidePopup()
        {
            await Task.Delay(3000);
            await PopupNavigation.RemovePageAsync(this);
        }

        void Handle_OnFinish(object sender, System.EventArgs e)
        {
            //formsanimation.IsPlaying = false;
            //formsanimation.AutoPlay = false;
            //formsanimation.IsVisible = false;
            //formsanimation.Loop = false;
        }
    }
}

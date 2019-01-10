using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace AppXamarim.ViewModel
{
    public class CameraViewModel:BaseViewModel
    {
        private IServiceMessage _message;
        private IServiceNavigation _navigation;

        public CameraViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _message = message;
            _navigation = navigation;
        }


        #region Commands


        /// <summary>
        /// Gets the tirar foto command.
        /// </summary>
        /// <value>The tirar foto command.</value>
        public ICommand TirarFotoCommand
        {
            get
            {
                return new Command(async (value) =>
                {

                    TirarFoto();
                });
            }
        }



        /// <summary>
        /// Gets the escolher foto command.
        /// </summary>
        /// <value>The escolher foto command.</value>
        public ICommand EscolherFotoCommand
        {
            get
            {
                return new Command(async (value) =>
                {

                    EscolherFoto();
                });
            }
        }

        /// <summary>
        /// Gets the gravar video command.
        /// </summary>
        /// <value>The gravar video command.</value>
        public ICommand GravarVideoCommand
        {
            get
            {
                return new Command(async (value) =>
                {

                    GravarVideo();
                });
            }
        }


        public ICommand EscolherVideoCommand
        {
            get
            {
                return new Command(async (value) =>
                {

                    EscolherVideo();
                });
            }
        }
        #endregion



        private async void TirarFoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await _message.DisplayAlert("Nenhuma câmera detectada.");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "TRASH"
                });

            if (file == null)
                return;

            MinhaImagem = file.Path;
        }

        private async void EscolherFoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await _message.DisplayAlert("Galeria de fotos não suportada.");

                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            MinhaImagem = file.Path;
        }

        private async void GravarVideo()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakeVideoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await _message.DisplayAlert("Nenhuma câmera detectada.");

                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(
                new StoreVideoOptions
                {
                    SaveToAlbum = true,
                    Directory = "TRASH",
                    Quality = VideoQuality.Medium
                });

            if (file == null)
                return;

            MinhaImagem = file.Path;
        }

        private async void EscolherVideo()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await _message.DisplayAlert("Galeria de videos não suportada.");

                return;
            }

            var file = await CrossMedia.Current.PickVideoAsync();

            if (file == null)
                return;

            MinhaImagem = file.Path;
        }


        #region Properties

        private string minhaImagem = "";
        public string MinhaImagem { get { return minhaImagem; } set { this.Set("MinhaImagem", ref minhaImagem, value); } }

        #endregion
    }
}

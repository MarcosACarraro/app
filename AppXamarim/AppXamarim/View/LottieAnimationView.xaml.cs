using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarim.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LottieAnimationView : ContentPage
	{
		public LottieAnimationView ()
		{
			InitializeComponent ();

            //var formsanimation = new Lottie.Forms.AnimationView();
            //formsanimation.Animation = "loading.json";
            //formsanimation.Loop = true;
            //formsanimation.AutoPlay = true;
            //formsanimation.VerticalOptions = LayoutOptions.FillAndExpand;
            //formsanimation.HorizontalOptions = LayoutOptions.FillAndExpand;
            //formsanimation.BackgroundColor = Color.Blue;
       
            //Content = formsanimation;
        }
	}
}
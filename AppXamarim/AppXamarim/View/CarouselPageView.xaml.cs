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
	public partial class CarouselPageView : ContentPage
	{
		public CarouselPageView ()
		{
			InitializeComponent ();
		}

        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            //Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            //Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            //Debug.WriteLine("Direction = " + e.Direction);
        }
    }
}
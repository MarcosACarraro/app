using AppXamarim.Service.Navigation;
using AppXamarim.ViewModel.ViewModelLocator;
using DLToolkit.Forms.Controls;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppXamarim
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitPlugin();
            InitializeNavitation();

            // MainPage = new MainPage();
        }

        public Task InitializeNavitation()
        {
            var navigation = Locator.Instance.Resolve<IServiceNavigation>();
            return navigation.InitializeAsync();
        }

        private void InitPlugin()
        {
            FlowListView.Init();
         
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

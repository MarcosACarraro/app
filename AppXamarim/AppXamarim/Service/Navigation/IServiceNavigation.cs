using AppXamarim.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarim.Service.Navigation
{
    public interface IServiceNavigation
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel:BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType , object parameter);
    }
}

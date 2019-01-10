using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarim.ViewModel
{
    public class BaseViewModel:ViewModelBase
    {
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}

using AppXamarim.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarim.Service
{
    public interface IGetService
    {
        Task<UserModel> GetAsync();
    }
}

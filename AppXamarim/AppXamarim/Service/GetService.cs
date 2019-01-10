using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppXamarim.Model;
using Newtonsoft.Json;

namespace AppXamarim.Service
{
    public class GetService : IGetService
    {
        public GetService()
        {
        }

        public async Task<UserModel> GetAsync()
        {
            UserModel lstResult = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var uri = "https://reqres.in/api/users?page=1";
                    var responseTask = await client.GetAsync(uri).ConfigureAwait(false);
                    if (responseTask.IsSuccessStatusCode)
                    {
                        var response = responseTask;

                        var res = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(res.ToString()))
                        {
                            lstResult = JsonConvert.DeserializeObject<UserModel>(res);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }

            return lstResult;
        }
    }
}

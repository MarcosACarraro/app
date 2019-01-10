using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.Model
{
    public class UserModel
    {
        public List<DataModel> data { get; set; }
    }

    public class DataModel
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public string first_name { get; set; }
    }
}

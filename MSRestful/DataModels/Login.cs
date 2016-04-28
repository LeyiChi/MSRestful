using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.DataModels
{
    public class Login
    {
        public string userId { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }

    public class User
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string occupation { get; set; }
        public string position { get; set; }
        public string affiliation { get; set; }

    }
}
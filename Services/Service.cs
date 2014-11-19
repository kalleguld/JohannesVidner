using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {
        private static Service _instance;
        public bool LoggedIn { get; set; }

        private Service() { }

        public static Service GetInstance()
        {
            return _instance ?? (_instance = new Service());
        }
    }
}

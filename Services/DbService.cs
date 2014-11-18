using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class DbService
    {
        private static DbService _instance;

        private DbService()
        {
            //TODO 
        }
        public static DbService Instance
        {
            get { return _instance ?? (_instance = new DbService()); }
        }
    }
}

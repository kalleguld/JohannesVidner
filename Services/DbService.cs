using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public class DbService
    {
        private ModelClassesContainer _dbContext;
        private static DbService _instance;

        private DbService()
        {
            //TODO 
        }
        public static DbService Instance
        {
            get { return _instance ?? (_instance = new DbService()); }
        }

        public User GetUser(string username,string password)
        {
            return _dbContext.UserSet.ToList().Where(u => u.Username == username && u.Password == password);
        }
    }
}

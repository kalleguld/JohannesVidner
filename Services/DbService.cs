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
        private ModelClassesContainer _dbContext = new ModelClassesContainer();
        private static DbService _instance;

        private DbService()
        {
            //TODO 
        }
        public static DbService Instance
        {
            get { return _instance ?? (_instance = new DbService()); }
        }

        public User GetUserByUsernameAndPassword(string username,string password)
        {
            List<User> list = (_dbContext.UserSet.ToList().Where(u => u.Username == username && u.PasswordText == password)).ToList();

            if (list.Count != 0)
            {
                return list[0];
            }
            return null;
        }
    }
}

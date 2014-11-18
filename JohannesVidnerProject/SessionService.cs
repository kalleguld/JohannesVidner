using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Model;

namespace JohannesVidnerProject
{
    public class SessionService
    {
        private SessionService()
        {
            //TODO 
        }

        private static SessionService _instance;
        public static SessionService Instance
        {
            get { return _instance ?? (_instance = new SessionService()); }
        }

        public  User CurrentUser
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
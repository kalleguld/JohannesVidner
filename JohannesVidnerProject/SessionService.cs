using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using Model;
using Services;

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

        public User CurrentUser { get; set; }
    
    }
}
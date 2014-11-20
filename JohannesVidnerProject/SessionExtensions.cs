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

    public static class SessionExtensions
    {
        public static User GetCurrentUser(this HttpSessionStateBase baseSession)
        {
            return baseSession["CurrentUser"] as User;
        }

        public static void SetCurrentUser(this HttpSessionStateBase baseSession, User user)
        {
            baseSession["CurrentUser"] = user;
        }


    }
}
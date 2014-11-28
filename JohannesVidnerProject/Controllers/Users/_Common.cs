using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController : Controller
    {
        private readonly DbService _dbService = DbService.Instance;

        private ActionResult GetRedirectIfNotUserAdmin(User user)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (!user.UserAdminAccess)
            {
                return RedirectToAction("Logoff", "Home");
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var sessionService = SessionService.Instance;
            var currentUser = sessionService.CurrentUser;
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!currentUser.IsUserAdmin)
            {
                //TODO redirect to an error page instead of giving an empty list
                return View(new List<User>());
            }

            var dbService = DbService.Instance;
            var users = dbService.GetUsersByPublicationRecursive(currentUser.Publication);
            return View(users);
        }

        public ActionResult Create()
        {
            var sessionService = SessionService.Instance;
            var currentUser = sessionService.CurrentUser;
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!currentUser.IsUserAdmin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
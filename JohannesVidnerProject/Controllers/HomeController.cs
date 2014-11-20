using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.Owin;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (SessionService.Instance.CurrentUser == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Login" });   
            }
            return View(SessionService.Instance.CurrentUser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Http GET
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";

            return View();
        }

        // POST: 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            SessionService.Instance.CurrentUser = DbService.Instance.GetUserByUsernameAndPassword(model.Email, model.Password);

            if (SessionService.Instance.CurrentUser != null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            ModelState.AddModelError("","Error in email or password");
            return View(model);
        }

        public ActionResult PublicationList()
        {
            return View(DbService.Instance.GetPublications());
        }
    }
}
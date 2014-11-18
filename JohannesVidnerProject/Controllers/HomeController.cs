using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
using Microsoft.AspNet.Identity.Owin;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (!Service.GetInstance().LoggedIn)
            {
                Service.GetInstance().LoggedIn = true;
                return RedirectToRoute(new { controller = "Home", action = "Login" });   
            }
            return View();
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

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // lav tjek på om pw og email er ok
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
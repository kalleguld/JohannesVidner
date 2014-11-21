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
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Login" });
            }
            var ans = new List<HomeIndexViewModel>();
            var publications = DbService.Instance.GetPublications(currentUser);
            foreach (var publication in publications)
            {
                var viewModel = new HomeIndexViewModel();
                var e = publication.Editions.Last();
                viewModel.Name = publication.Name;
                viewModel.NumberOfPages = Convert.ToInt32(e.NumberOfPages);
                viewModel.ErrorMessage = e.ErrorMessage;
                viewModel.RunningStarted = e.RunningStarted;
                viewModel.Running = e.Running;
                viewModel.Status = e.CurrentStatus;
                var mpages = new List<Page>();
                mpages.AddRange(e.MissingPages);
                viewModel.MissingPages = mpages;
                viewModel.DetermineStatusColor();
                ans.Add(viewModel);
            }
            // Sort by name
            var ans2 = ans.OrderBy(vm => vm.Name);
            // Sort by color - red, yellow, green
            var newans = new List<HomeIndexViewModel>(ans.Count);
            newans.AddRange(ans2.Where(vm => vm.CssClass == "danger"));
            newans.AddRange(ans2.Where(vm => vm.CssClass == "warning"));
            newans.AddRange(ans2.Where(vm => vm.CssClass == "success"));
            return View(newans);
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

        public ActionResult Logoff()
        {
            ViewBag.Message = "Your Logoff page.";

            return View();
        }

        // POST: 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            var newUser = DbService.Instance.GetUserByUsernameAndPassword(model.Username, model.Password);
            Session.SetCurrentUser(newUser);

            if (newUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Error in username or password");
            return View(model);
        }
    }
}
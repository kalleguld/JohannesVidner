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
                return RedirectToAction("Login", "Home");
            }
            var viewModels = new List<HomeIndexViewModel>();
            var publications = DbService.Instance.GetdescendantPublications(currentUser.Publication);
            publications.RemoveAll(p => p.Editions.Count == 0);
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
                viewModels.Add(viewModel);
            }
            // Sort by color - red, yellow, green
            var ans = new List<HomeIndexViewModel>(viewModels.Count);
            ans.AddRange(viewModels.Where(vm => vm.CssClass == "danger"));
            ans.AddRange(viewModels.Where(vm => vm.CssClass == "warning"));
            ans.AddRange(viewModels.Where(vm => vm.CssClass == "success"));
            return View(ans);
        }


        public ActionResult Contact()
        {
            return View();
        }

        // Http GET
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session.SetCurrentUser(null);

            return RedirectToAction("Login");
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
            model.Password = "";
            return View(model);
        }
    }
}
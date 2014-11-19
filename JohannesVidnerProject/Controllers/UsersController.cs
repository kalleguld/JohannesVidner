using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
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
            if (!currentUser.UserAdminAccess)
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
            if (!currentUser.UserAdminAccess)
            {
                return RedirectToAction("Index", "Home");
            }
            var viewModel = new CreateUserViewModel();
            var dbService = DbService.Instance;
            var allowedPublications = dbService.GetUsersByPublicationRecursive(currentUser.Publication);
            viewModel.AllowedPublications = new List<SelectListItem>(allowedPublications.Count);
            foreach (var publication in allowedPublications)
            {
                viewModel.AllowedPublications.Add(
                    new SelectListItem
                        {
                            Text  = publication.Name, 
                            Value = publication.Id.ToString()
                        });
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel viewModel)
        {
            var sessionService = SessionService.Instance;
            var currentUser = sessionService.CurrentUser;
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!currentUser.UserAdminAccess)
            {
                return RedirectToAction("Index", "Home");
            }
            var dbService = DbService.Instance;
            var targetPublication = dbService.GetPublicationById(viewModel.SelectedPublicationId);
            
            if (!dbService.IsDesendent(currentUser.Publication, targetPublication))
            {
                //This should only happen if user has changed some html or http
                return RedirectToAction("Index", "Home");
            }
            var newUser = dbService.CreateUser(viewModel.Username,
                                               viewModel.Password,
                                               viewModel.Name,
                                               targetPublication);
            newUser.UserAdminAccess = viewModel.UserAdmin;
            newUser.WriteAccess = viewModel.WriteAccess;

            return RedirectToAction("Index", "Users");
        }
}
}
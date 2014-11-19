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
                return View(new List<ListUsersViewModel>());
            }
            var users = new List<ListUsersViewModel>();
            PopulateUsersList(users, currentUser.Publication);

            return View(users);
        }

        private static void PopulateUsersList(List<ListUsersViewModel> targetUsers, Publication publication)
        {
            targetUsers.AddRange(publication.Users.Select(user => new ListUsersViewModel(user)));
            foreach (var child in publication.ChildPublications)
            {
                PopulateUsersList(targetUsers, child);
            }
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
            var viewModel = new CreateUserViewModel(currentUser.Publication);
            
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

        public ActionResult Edit
    }
}
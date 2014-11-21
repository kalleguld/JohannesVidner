using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
using JohannesVidnerProject.Models.Users;
using Microsoft.Ajax.Utilities;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
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
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
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
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
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
            var user = new User
            {
                Username =          viewModel.Username,
                Name =              viewModel.Name,
                PasswordText =      viewModel.Password,
                Publication =       targetPublication,
                UserAdminAccess =   viewModel.UserAdmin,
                WriteAccess =       viewModel.WriteAccess
            };
            dbService.Create(user);

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Edit()
        {
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (!currentUser.UserAdminAccess)
            {
                return RedirectToAction("Error", "Shared");
            }
            var userIdObj = Request.RequestContext.RouteData.Values["id"];
            int userId;
            if (!int.TryParse((string)userIdObj, out userId))
            {
                return RedirectToAction("Error", "Shared");
            }
            var dbService = DbService.Instance;
            var user = dbService.GetUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            var userViewModel = new EditUserViewModel(user, currentUser.Publication);
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel viewModel)
        {
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            if (!currentUser.UserAdminAccess)
            {
                return RedirectToAction("Error", "Shared");
            }
            var dbService = DbService.Instance;
            var targetUser = dbService.GetUserById(viewModel.UserId);
            if (!dbService.IsDesendent(targetUser.Publication, currentUser.Publication))
            {
                return RedirectToAction("Error", "Shared");
            }
            if (targetUser.PublicationId != viewModel.SelectedPublicationId)
            {
                var newPublication = dbService.GetPublicationById(viewModel.SelectedPublicationId);
                if (!dbService.IsDesendent(newPublication, currentUser.Publication))
                {
                    return RedirectToAction("Error", "Shared");
                }
                targetUser.Publication = newPublication;
            }

            if (!viewModel.Password.IsNullOrWhiteSpace())
            {
                targetUser.PasswordText = viewModel.Password;
            }
            targetUser.Name = viewModel.Name;
            targetUser.Username = viewModel.Username;
            targetUser.UserAdminAccess = viewModel.UserAdmin;
            targetUser.WriteAccess = viewModel.WriteAccess;
            dbService.Update(targetUser);

            return RedirectToAction("Index", "Users");
        }
    }
}
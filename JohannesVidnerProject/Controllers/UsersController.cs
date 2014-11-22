using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
using JohannesVidnerProject.Models.Users;
using Microsoft.Ajax.Utilities;
using Model;
using Model.Extensions;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

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
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

            var viewModel = new CreateUserViewModel(currentUser.Publication);
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel viewModel)
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

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

            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

            var userIdObj = Request.RequestContext.RouteData.Values["id"];
            int userId;
            if (!int.TryParse((string)userIdObj, out userId))
            {
                return RedirectToAction("Index");
            }
            var dbService = DbService.Instance;
            var user = dbService.GetUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var userViewModel = new EditUserViewModel(user, currentUser.Publication);
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel viewModel)
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

            var dbService = DbService.Instance;
            var targetUser = dbService.GetUserById(viewModel.UserId);
            if (!dbService.IsDesendent(targetUser.Publication, currentUser.Publication))
            {
                //currentUser is trying to move a user who doesn't work for currentUser
                return RedirectToAction("Error", "Home");
            }
            if (targetUser.PublicationId != viewModel.SelectedPublicationId)
            {
                var newPublication = dbService.GetPublicationById(viewModel.SelectedPublicationId);
                if (!dbService.IsDesendent(newPublication, currentUser.Publication))
                {
                    //currentUser is trying to make another user work at a place he can't
                    return RedirectToAction("Error", "Home");
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

        public ActionResult Delete()
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;
            var targetUser = GetUserFromRequestId();
            if (targetUser == null) return RedirectToAction("Index");

            var vm = new DeleteUserViewModel
            {
                Name = targetUser.Name,
                Username = targetUser.Username,
                UserId = targetUser.Id,
                HasSeenConfirmation = true
                
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteUserViewModel vm)
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;
            var targetUserId = vm.UserId;
            var dbService = DbService.Instance;
            var targetUser = dbService.GetUserById(targetUserId);

            if (targetUser == null) return RedirectToAction("Index");
            if (!targetUser.Publication.IsDesendent(currentUser.Publication)) return RedirectToAction("Error", "Home");

            dbService.Delete(targetUser);
            return RedirectToAction("Index");
        }


        private User GetUserFromRequestId()
        {
            var userIdObj = Request.RequestContext.RouteData.Values["id"];
            int userId;
            if (!int.TryParse((string)userIdObj, out userId))
            {
                return null;
            }
            var dbService = DbService.Instance;
            var user = dbService.GetUserById(userId);
            return user;
        }
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
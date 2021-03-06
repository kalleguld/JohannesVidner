﻿using System.Web.Mvc;
using JohannesVidnerProject.Models.Users;
using Microsoft.Ajax.Utilities;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController
    {
        public ActionResult Edit(int? id)
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;
            if (!id.HasValue) return RedirectToAction("Index");

            var user = _dbService.GetUserById(id.Value);
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

            var targetUser = _dbService.GetUserById(viewModel.UserId);
            if (!targetUser.Publication.IsDescendant(currentUser.Publication))
            {
                //currentUser is trying to move a user who doesn't work for currentUser
                return RedirectToAction("Index", "Home");
            }
            if (targetUser.PublicationId != viewModel.SelectedPublicationId)
            {
                var newPublication = _dbService.GetPublicationById(viewModel.SelectedPublicationId);
                if (!newPublication.IsDescendant(currentUser.Publication))
                {
                    //currentUser is trying to make another user work at a place he can't
                    return RedirectToAction("Index", "Home");
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
            targetUser.CultureName = viewModel.SelectedCulture;
            _dbService.Update(targetUser);

            return RedirectToAction("Index", "Users");
        }
    }
}
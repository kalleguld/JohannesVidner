using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Users;
using Model;

namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController
    {
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
            var targetUser = _dbService.GetUserById(targetUserId);

            if (targetUser == null) return RedirectToAction("Index");
            if (!targetUser.Publication.IsDescendant(currentUser.Publication))
            {
                //User tried to delete another user who doesn't work for him
                return RedirectToAction("Index", "Home");
            }

            _dbService.Delete(targetUser);
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
            var user = _dbService.GetUserById(userId);
            return user;
        }
    }
}
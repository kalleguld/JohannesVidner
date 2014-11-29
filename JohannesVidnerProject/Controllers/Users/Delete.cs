using System.Web.Mvc;
using JohannesVidnerProject.Models.Users;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController
    {
        public ActionResult Delete(int? id)
        {

            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;
            if (!id.HasValue) return RedirectToAction("Index");

            var targetUser = _dbService.GetUserById(id.Value);
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
            if (!vm.HasSeenConfirmation) return RedirectToAction("index");
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

    }
}
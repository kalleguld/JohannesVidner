using System.Web.Mvc;
using JohannesVidnerProject.Models.Users;
using Model;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController
    {
        public ActionResult Create()
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

            var viewModel = new CreateUserViewModel(currentUser.Publication);
            viewModel.SelectedCulture = currentUser.CultureName;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserViewModel viewModel)
        {
            var currentUser = Session.GetCurrentUser();
            var redirect = GetRedirectIfNotUserAdmin(currentUser);
            if (redirect != null) return redirect;

            var targetPublication = _dbService.GetPublicationById(viewModel.SelectedPublicationId);

            if (!targetPublication.IsDescendant(currentUser.Publication))
            {
                //This should only happen if user has changed some html or http
                return RedirectToAction("Index", "Home");
            }
            var user = new User
            {
                Username = viewModel.Username,
                Name = viewModel.Name,
                PasswordText = viewModel.Password,
                Publication = targetPublication,
                UserAdminAccess = viewModel.UserAdmin,
                WriteAccess = viewModel.WriteAccess,
                CultureName = viewModel.SelectedCulture
            };
            _dbService.Create(user);

            return RedirectToAction("Index");
        }
    }
}
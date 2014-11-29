using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Users;
using Model;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController
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
    }
}
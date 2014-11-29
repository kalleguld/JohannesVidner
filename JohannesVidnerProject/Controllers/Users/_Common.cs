using System.Web.Mvc;
using Model;
using Services;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class UsersController : Controller
    {
        private readonly DbService _dbService = DbService.Instance;

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
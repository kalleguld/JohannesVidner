using System.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class HomeController
    {
        public ActionResult Logoff()
        {
            Session.SetCurrentUser(null);

            return RedirectToAction("Login");
        }
    }
}
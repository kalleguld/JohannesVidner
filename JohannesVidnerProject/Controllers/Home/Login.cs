using System.Web.Mvc;
using JohannesVidnerProject.Models.Home;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class HomeController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            var newUser = _dbService.GetUserByUsernameAndPassword(model.Username, model.Password);
            Session.SetCurrentUser(newUser);

            if (newUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Error in username or password");
            model.Password = "";
            return View(model);
        }
    }
}
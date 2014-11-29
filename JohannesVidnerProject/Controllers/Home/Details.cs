using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Home;
using Model;
using Services;

// ReSharper disable once CheckNamespace
namespace JohannesVidnerProject.Controllers
{
    public partial class HomeController
    {
        public ActionResult Details(DetailViewModel hvm)
        {
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null) return RedirectToAction("Login", "Home");

            string idStr = Request.RequestContext.RouteData.Values["id"].ToString();
            int id;
            if (!int.TryParse(idStr, out id))
            {
                return RedirectToAction("Login", "Home");
            }
            var publication = DbService.Instance.GetPublicationById(id);
            if (publication == null) return RedirectToAction("Login", "Home");
            if (!publication.Editions.Any()) return RedirectToAction("Login", "Home");
            
            var dmv = new DetailViewModel(publication, currentUser.WriteAccess);
            
            return View(dmv);
        }
    }
}
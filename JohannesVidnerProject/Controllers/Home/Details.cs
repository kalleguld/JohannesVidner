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
        public ActionResult Details(int? id)
        {
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null) return RedirectToAction("Login", "Home");
            if (!id.HasValue) return RedirectToAction("Index");

            var publication = DbService.Instance.GetPublicationById(id.Value);
            if (publication == null) return RedirectToAction("Login", "Home");
            if (!publication.Editions.Any()) return RedirectToAction("Login", "Home");
            
            var dmv = new DetailViewModel(publication, currentUser.WriteAccess);
            
            return View(dmv);
        }
    }
}
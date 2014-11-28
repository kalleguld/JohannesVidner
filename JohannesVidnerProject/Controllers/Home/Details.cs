using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Home;
using Model;
using Services;

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
            var edition = publication.Editions.LastOrDefault();
            if (edition == null) return RedirectToAction("Login", "Home");
            var mpages = new List<Page>(edition.MissingPages);

            var dmv = new DetailViewModel
            {
                ShortName = publication.ShortName,
                EditionId = edition.Id,
                RunningStarted = edition.RunningStarted,
                LogText = edition.LogText,
                NumberOfPages = edition.NumberOfPages,
                MaxMissingPages = edition.MaxMissingPages,
                Id = edition.PublicationId,
                LastLogCheck = edition.LastLogCheck,
                ExpectedReleaseTime = edition.ExpectedReleaseTime,
                MissingPages = mpages,
                Status = edition.CurrentStatus,
                ShowRerunButton = currentUser.WriteAccess &&
                                  (edition.CurrentStatus != CurrentStatus.Running),
                ShowReleaseButton = currentUser.WriteAccess &&
                                    (edition.CurrentStatus == CurrentStatus.OnHold),
                ShowShowLogButton = currentUser.WriteAccess
            };
            return View(dmv);
        }
    }
}
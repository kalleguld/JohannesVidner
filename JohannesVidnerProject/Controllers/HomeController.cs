using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Home;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(IndexViewModel viewModel)
        {
            if (viewModel == null) viewModel = new IndexViewModel();

                                                        //check for login
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var publicationDepths = DbService.Instance.GetDescendantPublicationDepths(currentUser.Publication);

                                                        //Fill the main list of publications
            var publicationViewModels = new List<PublicationViewModel>();
            foreach (var pd in publicationDepths.Where(p => p.Publication.Editions.Count > 0))
            {
                var pvm = new PublicationViewModel();
                var publication = pd.Publication;
                var edition = publication.Editions.LastOrDefault();
                if (edition == null) continue;
                pvm.Name = publication.Name;
                pvm.NumberOfPages = Convert.ToInt32(edition.NumberOfPages);
                pvm.ErrorMessage = edition.ErrorMessage;
                pvm.RunningStarted = edition.RunningStarted;
                pvm.Running = edition.Running;
                pvm.Status = edition.CurrentStatus;
                var mpages = new List<Page>();
                mpages.AddRange(edition.MissingPages);
                pvm.MissingPages = mpages;
                pvm.DetermineStatusColor();
                publicationViewModels.Add(pvm);
            }
                                                        // Sort by color - red, yellow, green
            var sortedPubs = new List<PublicationViewModel>(publicationViewModels.Count);
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "danger"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "warning"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "success"));

            viewModel.PublicationViewModels = sortedPubs;

                                                        //Fill the filtering dropdown box with publications
            var publicationDropdownItems = new List<SelectListItem>(publicationDepths.Count);
            publicationDropdownItems.AddRange(publicationDepths.Select(pd => new SelectListItem
            {
                Value = pd.Publication.Id.ToString(), 
                Text = new string('-', pd.Depth) + pd.Publication.Name
            }));

            viewModel.PublicationDropdownItems = publicationDropdownItems;

            return View(viewModel);

        }


        public ActionResult Contact()
        {
            return View();
        }

        // Http GET
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session.SetCurrentUser(null);

            return RedirectToAction("Login");
        }

        // POST: 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            var newUser = DbService.Instance.GetUserByUsernameAndPassword(model.Username, model.Password);
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
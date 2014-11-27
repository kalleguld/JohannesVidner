﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using JohannesVidnerProject.Models;
using JohannesVidnerProject.Models.Home;
using Model;
using Resources;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly DbService _dbService = DbService.Instance;

        public ActionResult Index(IndexViewModel viewModel)
        {
            if (viewModel == null) viewModel = new IndexViewModel();

                                                        //check for login
            var currentUser = Session.GetCurrentUser();
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            //Take the topmost publication 
                                                        //from the dropdown
            var topmostPublication = TopmostPublication(viewModel.p, currentUser);
            //Fill the main list of publications
            IEnumerable<Publication> filteredPublications = _dbService.GetdescendantPublications(topmostPublication);
            filteredPublications = filteredPublications.Where(p => p.Editions.Any());

            if(!string.IsNullOrEmpty(viewModel.q))
                 filteredPublications = SearchPublications(filteredPublications, viewModel.q);

            var publicationViewModels = new List<PublicationViewModel>();
            foreach (var publication in filteredPublications)
            {
                var edition = publication.Editions.LastOrDefault();
                if (edition == null) continue;
                var pvm = new PublicationViewModel
                {
                    Id = publication.Id,
                    Name = publication.Name,
                    NumberOfPages = Convert.ToInt32(edition.NumberOfPages),
                    RunningStarted = edition.RunningStarted,
                    Running = edition.Running,
                    Status = edition.CurrentStatus,
                    MissingPages = new List<Page>(edition.MissingPages),
                };
                publicationViewModels.Add(pvm);
            }
                                                        // Sort by color - red, yellow, green
            var sortedPubs = new List<PublicationViewModel>(publicationViewModels.Count);
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "danger"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "warning"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "success"));

            viewModel.PublicationViewModels = sortedPubs;

                                                        //Fill the filtering dropdown box with publications
            var publicationDepths = DbService.Instance.GetDescendantPublicationDepths(currentUser.Publication);
            var publicationDropdownItems = new List<SelectListItem>(publicationDepths.Count);
            publicationDropdownItems.AddRange(publicationDepths.Select(pd => new SelectListItem
            {
                Value = pd.Publication.Id.ToString(), 
                Text = new string('-', pd.Depth) + pd.Publication.Name
            }));

            viewModel.PublicationDropdownItems = publicationDropdownItems;

            return View(viewModel);

        }

        private Publication TopmostPublication(int publicationId, User currentUser)
        {
            var topmostPublication = currentUser.Publication;
            var requestedPublication = _dbService.GetPublicationById(publicationId);
            if (requestedPublication == null) return topmostPublication;
            topmostPublication = requestedPublication;
            if (!topmostPublication.IsDescendant(currentUser.Publication))
            {
                topmostPublication = currentUser.Publication;
            }
            return topmostPublication;
        }

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
                PublicationId = edition.PublicationId,
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

        public IEnumerable<Publication> SearchPublications(IEnumerable<Publication> publications, string searchString)
        {
            
            var foundPublications = new List<Publication>();
            searchString = searchString.ToLower();
            var stringArray = searchString.Split(' ');            
            foreach (var pub in publications)
            {
                int foundCount = stringArray.Count(s => pub.Name.ToLower().Contains(s));
                if(foundCount == stringArray.Length)
                    foundPublications.Add(pub);
            }                       
            return foundPublications;
        }
    }
}
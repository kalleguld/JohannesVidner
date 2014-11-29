using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject.Models.Home;
using Model;
using Services;

namespace JohannesVidnerProject.Controllers
{
    public partial class HomeController
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

            var vm = FillViewModel(viewModel, currentUser.Publication);
            
            return View(vm);

        }

        private IndexViewModel FillViewModel(IndexViewModel viewModel, Publication currentUserPublication)
        {
            var topmostPublication = GetDeepestPublication(viewModel.p, currentUserPublication);
            //Fill the main list of publications
            IEnumerable<Publication> filteredPublications = _dbService.GetdescendantPublications(topmostPublication);
            filteredPublications = filteredPublications.Where(p => p.Editions.Any());

            if (!string.IsNullOrEmpty(viewModel.q))
                filteredPublications = SearchPublications(filteredPublications, viewModel.q);

            var publicationViewModels = new List<PublicationViewModel>();
            foreach (var publication in filteredPublications)
            {
                if (!publication.Editions.Any()) continue;
                var pvm = new PublicationViewModel(publication);
                publicationViewModels.Add(pvm);
            }
            // Sort by color - red, yellow, green
            var sortedPubs = new List<PublicationViewModel>(publicationViewModels.Count);
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "danger"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "warning"));
            sortedPubs.AddRange(publicationViewModels.Where(pvm => pvm.CssClass == "success"));

            viewModel.PublicationViewModels = sortedPubs;

            //Fill the filtering dropdown box with publications
            var publicationDepths = DbService.Instance.GetDescendantPublicationDepths(currentUserPublication);
            var publicationDropdownItems = new List<SelectListItem>(publicationDepths.Count);
            publicationDropdownItems.AddRange(publicationDepths.Select(pd => new SelectListItem
            {
                Value = pd.Publication.Id.ToString(),
                Text = new string('-', pd.Depth) + pd.Publication.Name
            }));

            viewModel.PublicationDropdownItems = publicationDropdownItems;

            return viewModel;
        }


        private Publication GetDeepestPublication(int possibleChildPublicationId, 
                                                  Publication parentPublication)
        {
            var ans = parentPublication;
            var requestedPublication = _dbService.GetPublicationById(possibleChildPublicationId);
            if (requestedPublication == null) return ans;
            ans = requestedPublication;
            if (!ans.IsDescendant(parentPublication))
            {
                ans = parentPublication;
            }
            return ans;
        }

        public IEnumerable<Publication> SearchPublications(IEnumerable<Publication> publications, string searchString)
        {

            var foundPublications = new List<Publication>();
            searchString = searchString.ToLower();
            var stringArray = searchString.Split(' ');
            foreach (var pub in publications)
            {
                int foundCount = stringArray.Count(s => pub.Name.ToLower().Contains(s));
                if (foundCount == stringArray.Length)
                    foundPublications.Add(pub);
            }
            return foundPublications;
        }
    }
}
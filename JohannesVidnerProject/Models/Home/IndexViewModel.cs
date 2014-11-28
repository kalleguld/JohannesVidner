using System.Collections.Generic;
using System.Web.Mvc;

namespace JohannesVidnerProject.Models.Home
{

    public class IndexViewModel
    {
        //The name of these two properties must be short, since they become part of the url when searching

        /// <summary>
        /// The search query
        /// </summary>
        public string q { get; set; }

        /// <summary>
        /// The ID of the selected publication
        /// </summary>
        public int p { get; set; }

        public ICollection<PublicationViewModel> PublicationViewModels { get; set; }
        public ICollection<SelectListItem> PublicationDropdownItems { get; set; }
    }
}
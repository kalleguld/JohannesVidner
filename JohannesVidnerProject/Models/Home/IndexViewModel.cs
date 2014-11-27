using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;

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

    public class PublicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RunningStarted { get; set; }
        public int NumberOfPages { get; set; }
        public string ErrorMessage { get; set; }
        public List<Page> MissingPages { get; set; } 
        public string CssClass { get; set; }

        public bool Running { get; set; }
        public CurrentStatus Status { get; set; }

        // maybe TODO: Change conditions for determining colors
        public void DetermineStatusColor()
        {
            CssClass = "danger";
            switch (Status)
            {
                case CurrentStatus.Released:
                    CssClass = "success";
                    break;
                case CurrentStatus.OnHold:
                    CssClass = "success";
                    break;
                case CurrentStatus.NotStarted:
                    CssClass = "warning";
                    break;
                case CurrentStatus.Running:
                    CssClass = "warning";
                    break;
            }
        }
    }
}
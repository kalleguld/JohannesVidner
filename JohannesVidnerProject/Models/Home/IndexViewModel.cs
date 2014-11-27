using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Resources;

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
        public List<Page> MissingPages { get; set; }

        public bool Running { get; set; }
        public CurrentStatus Status { get; set; }

        // maybe TODO: Change conditions for determining colors
        public void DetermineStatusColor()
        {
            
        }

        public string CssClass
        {
            get
            {
                switch (Status)
                {
                    case CurrentStatus.Released:
                        return "success";
                    case CurrentStatus.OnHold:
                        return "success";
                    case CurrentStatus.NotStarted:
                        return "warning";
                    case CurrentStatus.Running:
                        return "warning";
                    default:
                        return "danger";
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                var errorMessage = "";
                switch (Status)
                {
                    case CurrentStatus.Released:
                        errorMessage = langResources.Views_Home_Index_Released;
                        break;
                    case CurrentStatus.OnHold:
                        errorMessage = langResources.Views_Home_Index_OnHold;
                        break;
                    case CurrentStatus.NotStarted:
                        errorMessage = langResources.Views_Home_Index_NotStarted;
                        break;
                    case CurrentStatus.Running:
                        errorMessage = langResources.Views_Home_Index_Running;
                        break;
                    case CurrentStatus.UnrecoverableError:
                        errorMessage = langResources.Views_Home_Index_UnrecoverableError;
                        break;
                    case CurrentStatus.RecoverableError:
                        errorMessage = langResources.Views_Home_Index_RecoverableError;
                        break;
                }
                return errorMessage;
            }
        }

    }
}
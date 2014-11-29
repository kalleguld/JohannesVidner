using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Resources;

namespace JohannesVidnerProject.Models.Home
{
    public class PublicationViewModel
    {
        public PublicationViewModel() { /*Nothing*/ }
        public PublicationViewModel(Publication publication)
        {
            var edition = publication.Editions.Last();
            Id = publication.Id;
            Name = publication.Name;
            
            RunningStarted = edition.RunningStarted;
            NumberOfPages = edition.NumberOfPages;
            MissingPages = new List<Page>(edition.MissingPages);
            Status = edition.CurrentStatus;
            Running = edition.Running;

        }
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime RunningStarted { get; set; }
        public int NumberOfPages { get; set; }
        public List<Page> MissingPages { get; set; }
        public CurrentStatus Status { get; set; }

        public bool Running { get; set; }

     

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
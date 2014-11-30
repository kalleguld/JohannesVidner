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
            Id          = publication.Id;
            Name        = publication.Name;
            
            RunningStarted = edition.RunningStarted;
            NumberOfPages  = edition.NumberOfPages;
            Status         = edition.CurrentStatus;
            Running        = edition.Running;
            MissingPages   = new List<Page>(edition.MissingPages);

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
                switch (Status)
                {
                    case CurrentStatus.Released:
                        return langResources.Views_Home_Index_Released;
                    case CurrentStatus.OnHold:
                        return langResources.Views_Home_Index_OnHold;
                    case CurrentStatus.NotStarted:
                        return langResources.Views_Home_Index_NotStarted;
                    case CurrentStatus.Running:
                        return langResources.Views_Home_Index_Running;
                    case CurrentStatus.UnrecoverableError:
                        return langResources.Views_Home_Index_UnrecoverableError;
                    case CurrentStatus.RecoverableError:
                    default:
                        return langResources.Views_Home_Index_RecoverableError;
                }
            }
        }
    }
}
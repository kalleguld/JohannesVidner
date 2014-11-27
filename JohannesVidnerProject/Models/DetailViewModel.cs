using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Resources;

namespace JohannesVidnerProject.Models
{
    public class DetailViewModel
    {
        public int EditionId { get; set; }
        public DateTime RunningStarted { get; set; }
        public string LogText { get; set; }
        public int NumberOfPages { get; set; }
        public int MaxMissingPages { get; set; }
        public string ShortName { get; set; }
        public int PublicationId { get; set; }
        public DateTime LastLogCheck { get; set; }
        public DateTime? ExpectedReleaseTime { get; set; }
        public List<Page> MissingPages { get; set; }
        public CurrentStatus Status { get; set; }

        public bool ShowRerunButton { get; set; }
        public bool ShowReleaseButton { get; set; }
        public bool ShowShowLogButton { get; set; }

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
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Resources;

namespace JohannesVidnerProject.Models.Home
{
    public class DetailViewModel : PublicationViewModel
    {
        public DetailViewModel() { /*Nothing*/ }

        public DetailViewModel(Publication publication, bool userWriteAccess)
                        : base(publication)
        {
            ShortName = publication.ShortName;

            var edition = publication.Editions.Last();
            EditionId           = edition.Id;
            LogText             = edition.LogText;
            MaxMissingPages     = edition.MaxMissingPages;
            LastLogCheck        = edition.LastLogCheck;
            ExpectedReleaseTime = edition.ExpectedReleaseTime;

            ShowShowLogButton = userWriteAccess;
            ShowRerunButton   = userWriteAccess && (edition.CurrentStatus != CurrentStatus.Running);
            ShowReleaseButton = userWriteAccess && (edition.CurrentStatus == CurrentStatus.OnHold);
        }

        
        public string ShortName { get; set; }

        public int EditionId { get; set; }
        public string LogText { get; set; }
        public int MaxMissingPages { get; set; }
        public DateTime LastLogCheck { get; set; }
        public DateTime? ExpectedReleaseTime { get; set; }

        public bool ShowRerunButton { get; set; }
        public bool ShowReleaseButton { get; set; }
        public bool ShowShowLogButton { get; set; }

    }


}
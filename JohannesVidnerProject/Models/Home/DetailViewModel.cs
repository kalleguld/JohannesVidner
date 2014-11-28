using System;
using System.Collections.Generic;
using Model;
using Resources;

namespace JohannesVidnerProject.Models.Home
{
    public class DetailViewModel : PublicationViewModel
    {

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
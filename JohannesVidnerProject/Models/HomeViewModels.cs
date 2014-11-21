using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Model;

namespace JohannesVidnerProject.Models
{
    public class HomeIndexViewModel
    {
        public string Name { get; set; }
        public DateTime RunningStarted { get; set; }
        public int NumberOfPages { get; set; }
        public string ErrorMessage { get; set; }

        public string CssClass { get; set; }

        public bool Running { get; set; }
        public CurrentStatus Status { get; set; }

        // maybe TODO: Change conditions for determining colors
        public void DetermineStatusColor()
        {
            CssClass = "danger";
            if (ErrorMessage.StartsWith("Success"))
            {
                CssClass = "success";
                ErrorMessage = "Online";
            }
            if (Running || ErrorMessage.StartsWith("Hold"))
            {
                CssClass = "warning";
                ErrorMessage = "Running";
            }
        }
}
}
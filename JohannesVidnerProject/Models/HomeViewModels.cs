﻿using System;
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
                    ErrorMessage = "Online";
                    break;
                case CurrentStatus.OnHold:
                    CssClass = "success";
                    ErrorMessage = "Uploaded and ready for release";
                    break;
                case CurrentStatus.NotStarted:
                    CssClass = "warning";
                    ErrorMessage = "Not started";
                    break;
                case CurrentStatus.Running:
                    CssClass = "warning";
                    ErrorMessage = "Running...";
                    break;
                case CurrentStatus.UnrecoverableError:
                    ErrorMessage = "ERROR. CONTACT YOUR SUPERVISOR RIGHT NOW!!!";
                    break;
                case CurrentStatus.RecoverableError:
                    ErrorMessage = "An error has occured. The system will try to run the files again in 10 minutes.";
                    break;
            }
        }
    }
}
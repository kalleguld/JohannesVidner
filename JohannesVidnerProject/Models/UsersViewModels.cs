using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace JohannesVidnerProject.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public string Password { get; set; }

        public bool WriteAccess { get; set; }
        public bool UserAdmin { get; set; }

        [Required]
        public int SelectedPublicationId { get; set; }
        public ICollection<SelectListItem> AllowedPublications { get; set; } 


    }

}
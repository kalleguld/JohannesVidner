using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using JohannesVidnerProject.Helpers;
using Model;
using Resources;

namespace JohannesVidnerProject.Models.Users
{
    public abstract class CreateEditViewModel
    {
        protected CreateEditViewModel() { /*Nothing*/ }

        protected CreateEditViewModel(Publication creatorPublication)
        {
            AllowedPublications = new List<SelectListItem>();
            AddRecursive(creatorPublication, 0);
            SelectedPublicationId = creatorPublication.Id;
            AllowedCultures = new List<SelectListItem>();
            AllowedCultures.Add(new SelectListItem{Text = "", Value = ""});
            foreach (var culture in CultureHelper.AvailableCultures)
            {
                AllowedCultures.Add(new SelectListItem{Text = culture.NativeName, Value = culture.Name});
            }
            
        }

        [Required]
        [Display(Name = "Username")]
        public String Username { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Write access to publications")]
        public bool WriteAccess { get; set; }

        [Display(Name = "User Administrator")]
        public bool UserAdmin { get; set; }

        [Required]
        public int SelectedPublicationId { get; set; }
        public ICollection<SelectListItem> AllowedPublications { get; set; }

        public string SelectedCulture { get; set; }
        public ICollection<SelectListItem> AllowedCultures { get; set; } 


        protected void AddRecursive(Publication sourcePublication, int depth)
        {
            var listItemText = new string('-', depth) + sourcePublication.Name;
            var listItem = new SelectListItem
            {
                Text = listItemText, 
                Value = sourcePublication.Id.ToString()
            };
            AllowedPublications.Add(listItem);
            foreach (var childPublication in sourcePublication.ChildPublications)
            {
                AddRecursive(childPublication, depth + 1);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace JohannesVidnerProject.Models
{
    public class ListUsersViewModel
    {
        public ListUsersViewModel() { /*Nothing */ }
        public ListUsersViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Name = user.Name;
            Workplace = user.Publication.Name;
        }
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Workplace")]
        public string Workplace { get; set; }
    }


    
    public class CreateUserViewModel
    {
        public CreateUserViewModel() { /*Nothing*/ }

        public CreateUserViewModel(Publication creatorPublication)
        {
            AllowedPublications = new List<SelectListItem>();
            AddRecursive(creatorPublication, 0);
            SelectedPublicationId = creatorPublication.Id;
        }

        [Required]
        [Display(Name = "Username")]
        public String Username { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string MailAddress { get; set; }

        [Display(Name = "Write access to publications")]
        public bool WriteAccess { get; set; }

        [Display(Name = "User Administrator")]
        public bool UserAdmin { get; set; }

        [Required]
        public int SelectedPublicationId { get; set; }
        public ICollection<SelectListItem> AllowedPublications { get; set; }


        private void AddRecursive(Publication sourcePublication, int depth)
        {
            var listItemText = new string('-', depth) + sourcePublication.Name;
            var listItem = new SelectListItem {Text = listItemText, Value = sourcePublication.Id.ToString()};
            AllowedPublications.Add(listItem);
            foreach (var childPublication in sourcePublication.ChildPublications)
            {
                AddRecursive(childPublication, depth + 1);
            }
        }
    }

    public class EditUserViewModel : CreateUserViewModel
    {
        public EditUserViewModel() { /*Nothing*/ }
        public EditUserViewModel(Publication creatorPublication) : base(creatorPublication)
        {
            /* Nothing */
        }

        public EditUserViewModel(User user) : base(user.Publication)
        {
            Username = user.Username;
            Name = user.Name;
            WriteAccess = user.WriteAccess;
            UserAdmin = user.UserAdminAccess;
            SelectedPublicationId = user.PublicationId;
            UserId = user.Id;
        }

        public int UserId { get; set; }
    }


}
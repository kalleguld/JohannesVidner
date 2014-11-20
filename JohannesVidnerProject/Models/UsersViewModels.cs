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

    public abstract class CreateEditViewModel
    {
        internal CreateEditViewModel() { /*Nothing*/ }

        internal CreateEditViewModel(Publication creatorPublication)
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

        [Display(Name = "Write access to publications")]
        public bool WriteAccess { get; set; }

        [Display(Name = "User Administrator")]
        public bool UserAdmin { get; set; }

        [Required]
        public int SelectedPublicationId { get; set; }
        public ICollection<SelectListItem> AllowedPublications { get; set; }


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
    
    public class CreateUserViewModel : CreateEditViewModel
    {
        public CreateUserViewModel() { /*Nothing*/ }
        public CreateUserViewModel(Publication publication) : base(publication) { /*Nothing*/ }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    public class EditUserViewModel : CreateEditViewModel
    {
        public EditUserViewModel() { /*Nothing*/ }
        
        public EditUserViewModel(Publication publication, User targetUser) : base(publication)
        {
            Username = targetUser.Username;
            Name = targetUser.Name;
            WriteAccess = targetUser.WriteAccess;
            UserAdmin = targetUser.UserAdminAccess;
            SelectedPublicationId = targetUser.PublicationId;
            UserId = targetUser.Id;
        }


        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public int UserId { get; set; }
    }


}
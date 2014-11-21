using System.ComponentModel.DataAnnotations;
using Model;

namespace JohannesVidnerProject.Models.Users
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
}
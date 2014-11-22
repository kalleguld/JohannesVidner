using System.ComponentModel.DataAnnotations;
using Model;

namespace JohannesVidnerProject.Models.Users
{
    public class CreateUserViewModel : CreateEditViewModel
    {
        public CreateUserViewModel() { /*Nothing*/ }
        public CreateUserViewModel(Publication p) : base(p) { /*Nothing*/ }

        //Password is only required when creating a new user, not when editing an existing one
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
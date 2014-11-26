using System.ComponentModel.DataAnnotations;
using Model;

namespace JohannesVidnerProject.Models.Users
{
    public class EditUserViewModel : CreateEditViewModel
    {
        public EditUserViewModel() { /*Nothing*/ }
        public EditUserViewModel(Publication creatorPublication) : base(creatorPublication)
        {
            /* Nothing */
        }

        public EditUserViewModel(User user, Publication topmostPublication) : base(topmostPublication)
        {
            Username = user.Username;
            Name = user.Name;
            WriteAccess = user.WriteAccess;
            UserAdmin = user.UserAdminAccess;
            SelectedPublicationId = user.PublicationId;
            UserId = user.Id;
            SelectedCulture = user.CultureName;
        }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public int UserId { get; set; }
    }


}
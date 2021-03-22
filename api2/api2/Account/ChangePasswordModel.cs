using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }
    }
}

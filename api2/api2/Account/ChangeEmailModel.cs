using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    public class ChangeEmailModel
    {
        [Required(ErrorMessage = "New Email Address is required")]
        public string NewEmail { get; set; }
    }
}

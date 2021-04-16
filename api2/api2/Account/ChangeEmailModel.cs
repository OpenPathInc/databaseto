using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    /// <summary>
    /// Component model for changing the email
    /// </summary>
    public class ChangeEmailModel
    {
        /// <summary>
        /// This is the new email address
        /// </summary>
        [Required(ErrorMessage = "New Email Address is required")]
        public string NewEmail { get; set; }
    }
}

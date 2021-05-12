using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    /// <summary>
    /// Component model for changing the password
    /// </summary>
    public class EditAccountModel
    {
        /// <summary>
        /// This is the current password 
        /// </summary>
        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// This is the new password
        /// </summary>
        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        /// <summary>
        /// This is the new username
        /// </summary>
        [Required(ErrorMessage = "New Username is required")]
        public string NewUsername { get; set; }

        /// <summary>
        /// This is the new email address
        /// </summary>
        [Required(ErrorMessage = "New Email Address is required")]
        public string NewEmail { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    /// <summary>
    /// Component model for changing the password
    /// </summary>
    public class ChangePasswordModel
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
    }
}

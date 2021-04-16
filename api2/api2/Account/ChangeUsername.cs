using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    /// <summary>
    /// Component model for changing the username
    /// </summary>
    public class ChangeUsername
    {
        /// <summary>
        /// This is the new username
        /// </summary>
        [Required(ErrorMessage = "New Username is required")]
        public string NewUsername { get; set; }
    }
}

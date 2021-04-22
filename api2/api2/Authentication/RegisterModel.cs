using System.ComponentModel.DataAnnotations;

namespace api2.Authentication
{
    /// <summary>
    /// This is the register component model 
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// This is the required username
        /// </summary>
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        /// <summary>
        /// This is the required email address
        /// </summary>
        /// 
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        /// <summary>
        /// This is the required password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

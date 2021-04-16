using System.ComponentModel.DataAnnotations;

namespace api2.Authentication
{
    /// <summary>
    /// This is the login component model 
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// This is required username 
        /// </summary>
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        /// <summary>
        /// This is required password 
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

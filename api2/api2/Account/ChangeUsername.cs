using System.ComponentModel.DataAnnotations;

namespace api2.Account
{
    public class ChangeUsername
    {
        [Required(ErrorMessage = "New Username is required")]
        public string NewUsername { get; set; }
    }
}

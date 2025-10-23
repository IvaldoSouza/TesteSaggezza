using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password id required")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and atu max {1} characters long.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

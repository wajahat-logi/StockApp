using System.ComponentModel.DataAnnotations;

namespace JWTToken.Model.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}

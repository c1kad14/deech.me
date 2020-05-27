using System.ComponentModel.DataAnnotations;

namespace deech.me.idp.models
{
    public class RegisterInputModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
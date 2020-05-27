using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace deech.me.idp.viewmodels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class PasswordDto
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "New Password needs to be confrimed")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match")]
        public string NewPasswordConfirmed { get; set; }

    }
}

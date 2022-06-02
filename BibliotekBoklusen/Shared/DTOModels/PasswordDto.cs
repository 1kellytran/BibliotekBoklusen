using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class PasswordDto
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        [StringLength(32, ErrorMessage = "Lösenordet måste innehålla minst 6 karaktärer och max 32.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("NewPassword", ErrorMessage = "Lösenordet matchar inte")]
        public string? NewPasswordConfirmed { get; set; }
    }
}

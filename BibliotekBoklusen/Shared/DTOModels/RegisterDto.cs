using BibliotekBoklusen.Shared.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obligatoriskt fält")]
        [EmailAddress(ErrorMessage = "Ingen giltig emailadress")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt fält")]
        [StringLength(32, ErrorMessage = "Lösenordet måste innehålla minst 6 karaktärer och max 32.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenordet matchar inte")]
        public string ConfirmPassword { get; set; }
        public UserRole UserRole {get;set;}
}
}


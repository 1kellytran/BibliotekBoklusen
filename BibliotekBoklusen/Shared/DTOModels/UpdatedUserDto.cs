using BibliotekBoklusen.Shared.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class UpdatedUserDto
    {
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }
    }
}

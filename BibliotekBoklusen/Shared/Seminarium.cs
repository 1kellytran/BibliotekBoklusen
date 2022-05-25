using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class Seminarium
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Obligatorisk fält")]
        public string Title { get; set; } = String.Empty;
        [Required(ErrorMessage = "Obligatorisk fält")]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Obligatorisk fält")]
        public string LastName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Obligatorisk fält")]
        public DateTime DayAndTime { get; set; }
    }
}

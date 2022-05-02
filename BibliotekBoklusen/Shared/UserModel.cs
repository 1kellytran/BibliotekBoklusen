using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTime Created { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public UserStatus? Status { get; set; }
    }
}

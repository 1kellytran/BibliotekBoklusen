namespace BibliotekBoklusen.Shared
{
    public class UpdatedUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}

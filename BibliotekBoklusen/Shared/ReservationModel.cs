namespace BibliotekBoklusen.Shared
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}

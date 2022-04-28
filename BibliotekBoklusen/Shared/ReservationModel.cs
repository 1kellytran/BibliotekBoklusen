namespace BibliotekBoklusen.Shared
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}

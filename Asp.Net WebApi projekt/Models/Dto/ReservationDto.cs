namespace Asp.Net_WebApi_projekt.Models.Dto
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SwimmingTrackId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

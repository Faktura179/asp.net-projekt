namespace Asp.Net_WebApi_projekt.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SwimmingTrackId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Client Client { get; set; }
        public SwimmingTrack SwimmingTrack { get; set; }
    }
}

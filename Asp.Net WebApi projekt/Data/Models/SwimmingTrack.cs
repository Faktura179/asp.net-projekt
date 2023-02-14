using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Data.Models
{
    public class SwimmingTrack
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public int Length { get; set; }
        public int Capacity { get; set; }
        public int SwimmingPoolId { get; set; }

        public SwimmingPool SwimmingPool { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string FirstName { get; set; }
        [MaxLength(300)]
        public string LastName { get; set; }
        [MaxLength(300)]
        public string Email { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}

namespace Asp.Net_WebApi_projekt.Models.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<ReservationDto> Reservations { get; set; }
    }
}

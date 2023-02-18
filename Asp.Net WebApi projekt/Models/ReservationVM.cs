using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class ReservationVM
    {
        public ReservationVM(ReservationDto reservation)
        {
            Reservation = reservation;
        }

        public ReservationDto Reservation { get; set; }
    }
}

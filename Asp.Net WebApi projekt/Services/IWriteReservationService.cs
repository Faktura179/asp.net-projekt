using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Services
{
    public interface IWriteReservationService
    {
        Task Delete(int id);
        Task<int> Add(ReservationDto reservation);
    }
}

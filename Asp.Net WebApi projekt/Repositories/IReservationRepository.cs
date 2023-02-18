using Asp.Net_WebApi_projekt.Data.Models;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAll();
        Task<Reservation?> GetById(int id);
        Task Delete(int Id);
        void Add(Reservation reservation);
    }
}

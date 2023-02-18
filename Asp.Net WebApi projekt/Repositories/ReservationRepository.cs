using Asp.Net_WebApi_projekt.Data;
using Asp.Net_WebApi_projekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private DbSet<Reservation> _reservations;

        public ReservationRepository(ApplicationDbContext context)
        {
            _reservations = context.Set<Reservation>();
        }

        public Task<List<Reservation>> GetAll()
        {
            return _reservations.ToListAsync();
        }

        public Task<Reservation?> GetById(int id)
        {
            return _reservations
                .Include(x => x.SwimmingTrack.SwimmingPool)
                .Include(x => x.Client)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}

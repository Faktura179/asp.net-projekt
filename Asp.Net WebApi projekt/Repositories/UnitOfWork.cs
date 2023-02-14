using Asp.Net_WebApi_projekt.Data;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
            Clients = new ClientRepository(context);
            Reservations = new ReservationRepository(context);
            SwimmingPools= new SwimmingPoolRepository(context);
            SwimmingTracks= new SwimmingTrackRepository(context);
        }

        public IClientRepository Clients { get; private set; }

        public IReservationRepository Reservations { get; private set; }

        public ISwimmingPoolRepository SwimmingPools { get; private set; }

        public ISwimmingTrackRepository SwimmingTracks { get; private set; }

        public Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}

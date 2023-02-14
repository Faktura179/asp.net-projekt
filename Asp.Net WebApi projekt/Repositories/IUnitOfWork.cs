namespace Asp.Net_WebApi_projekt.Repositories
{
    public interface IUnitOfWork
    {
        public Task SaveChanges();

        IClientRepository Clients { get; }
        IReservationRepository Reservations { get; }
        ISwimmingPoolRepository SwimmingPools { get; }
        ISwimmingTrackRepository SwimmingTracks { get; }
    }
}

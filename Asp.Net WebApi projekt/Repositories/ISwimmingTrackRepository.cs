using Asp.Net_WebApi_projekt.Data.Models;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public interface ISwimmingTrackRepository
    {
        Task<List<SwimmingTrack>> GetAll();
        Task<SwimmingTrack?> GetById(int id);
    }
}

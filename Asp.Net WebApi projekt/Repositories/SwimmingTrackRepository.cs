using Asp.Net_WebApi_projekt.Data;
using Asp.Net_WebApi_projekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public class SwimmingTrackRepository : ISwimmingTrackRepository
    {
        private DbSet<SwimmingTrack> _swimmingTracks;

        public SwimmingTrackRepository(ApplicationDbContext context)
        {
            _swimmingTracks = context.Set<SwimmingTrack>();
        }

        public Task<List<SwimmingTrack>> GetAll()
        {
            return _swimmingTracks.ToListAsync();
        }

        public Task<SwimmingTrack?> GetById(int id)
        {
            return _swimmingTracks
                .Include(x => x.SwimmingPool)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using Asp.Net_WebApi_projekt.Data;
using Asp.Net_WebApi_projekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public class SwimmingPoolRepository : ISwimmingPoolRepository
    {
        private DbSet<SwimmingPool> _swimmingPools;

        public SwimmingPoolRepository(ApplicationDbContext context)
        {
            _swimmingPools = context.Set<SwimmingPool>();
        }

        public void Add(SwimmingPool swimmingPool)
        {
            _swimmingPools.Add(swimmingPool);
        }

        public Task<List<SwimmingPool>> GetAll()
        {
            return _swimmingPools.ToListAsync();
        }

        public Task<SwimmingPool?> GetById(int id)
        {
            return _swimmingPools.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using Asp.Net_WebApi_projekt.Data;
using Asp.Net_WebApi_projekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public class ClientRepository : IClientRepository

    {
        private DbSet<Client> _clients;
        private int _pageSize = 3;

        public ClientRepository(ApplicationDbContext context)
        {
            _clients = context.Set<Client>();
        }

        public Task<List<Client>> GetAll()
        {
            return _clients.ToListAsync();
        }

        public Task<Client?> GetById(int id)
        {
            return _clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> GetPagesCount()
        {
            return (int)Math.Ceiling((double)await _clients.CountAsync()/(double)_pageSize);
        }

        public Task<List<Client>> GetPaginated(int page)
        {
            return _clients.Skip(_pageSize * (page-1)).Take(_pageSize).ToListAsync();
        }
    }
}

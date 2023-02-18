using Asp.Net_WebApi_projekt.Data.Models;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task<int> GetPagesCount();
        Task<List<Client>> GetPaginated(int page);
    }
}

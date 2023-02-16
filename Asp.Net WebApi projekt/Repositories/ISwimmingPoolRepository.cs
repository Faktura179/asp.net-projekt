using Asp.Net_WebApi_projekt.Data.Models;

namespace Asp.Net_WebApi_projekt.Repositories
{
    public interface ISwimmingPoolRepository
    {
        Task<List<SwimmingPool>> GetAll();
        Task<SwimmingPool?> GetById(int id);
        void Add(SwimmingPool swimmingPool);
    }
}

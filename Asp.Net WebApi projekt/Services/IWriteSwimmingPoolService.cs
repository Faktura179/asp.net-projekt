using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Services
{
    public interface IWriteSwimmingPoolService
    {
        Task<int> Create(SwimmingPoolDto swimmingPool);
        Task<bool> Update(SwimmingPoolDto swimmingPool);
    }
}

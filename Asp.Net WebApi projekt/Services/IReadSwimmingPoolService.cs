using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Services
{
    public interface IReadSwimmingPoolService
    {
        Task<List<SwimmingPoolDto>> GetAll();
        Task<SwimmingPoolDto> GetById(int id);
    }
}

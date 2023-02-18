using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Services
{
    public interface IReadSwimmingTrackService
    {
        Task<SwimmingTrackDto> GetById(int id);
    }
}

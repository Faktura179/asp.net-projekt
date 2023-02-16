using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Services
{
    public interface IReadClientService
    {
        Task<List<ClientDto>> GetAll();
    }
}

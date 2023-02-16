using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class ReadClientService : IReadClientService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ReadClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClientDto>> GetAll()
        {
            return _mapper.Map<List<Client>, List<ClientDto>>(await _unitOfWork.Clients.GetAll());
        }
    }
}

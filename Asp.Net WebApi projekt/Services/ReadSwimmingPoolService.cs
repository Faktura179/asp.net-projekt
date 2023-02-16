using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class ReadSwimmingPoolService : IReadSwimmingPoolService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReadSwimmingPoolService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SwimmingPoolDto>> GetAll()
        {
            return _mapper.Map<List<SwimmingPool>, List<SwimmingPoolDto>>(await _unitOfWork.SwimmingPools.GetAll());
        }

        public async Task<SwimmingPoolDto> GetById(int id)
        {
            return _mapper.Map<SwimmingPool, SwimmingPoolDto>(await _unitOfWork.SwimmingPools.GetById(id) ?? throw new NullReferenceException($"Swimming pool with id {id} doesnt exist"));
        }
    }
}

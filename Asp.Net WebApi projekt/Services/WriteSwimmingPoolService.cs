using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class WriteSwimmingPoolService : IWriteSwimmingPoolService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WriteSwimmingPoolService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(SwimmingPoolDto swimmingPool)
        {
            SwimmingPool newSwimmingPool = _mapper.Map<SwimmingPoolDto, SwimmingPool>(swimmingPool);

            _unitOfWork.SwimmingPools.Add(newSwimmingPool);

            await _unitOfWork.SaveChanges();

            return newSwimmingPool.Id;
        }

        public async Task<bool> Update(SwimmingPoolDto swimmingPool)
        {
            var swimmingPoolToEdit = await _unitOfWork.SwimmingPools.GetById(swimmingPool.Id);
            if(swimmingPoolToEdit == null)
            {
                return false;
            }

            swimmingPoolToEdit.Name = swimmingPool.Name;
            swimmingPoolToEdit.Location = swimmingPool.Location;

            await _unitOfWork.SaveChanges();

            return true;
        }
    }
}

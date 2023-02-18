using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class ReadSwimmingTrackService : IReadSwimmingTrackService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ReadSwimmingTrackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SwimmingTrackDto> GetById(int id)
        {
            return _mapper.Map<SwimmingTrack, SwimmingTrackDto>(await _unitOfWork.SwimmingTracks.GetById(id));
        }
    }
}

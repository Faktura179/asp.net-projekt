using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class ReadReservationService : IReadReservationService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ReadReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDto> GetById(int id)
        {
            return _mapper.Map<Reservation,ReservationDto>(await _unitOfWork.Reservations.GetById(id));
        }
    }
}

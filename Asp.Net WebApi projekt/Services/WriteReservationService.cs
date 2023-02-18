using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Services
{
    public class WriteReservationService : IWriteReservationService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public WriteReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Add(ReservationDto reservation)
        {
            if (reservation.EndTime <= reservation.StartTime)
                throw new ArgumentException("Invalid start/end dates");

            Reservation newReservation = _mapper.Map<ReservationDto, Reservation>(reservation);

            _unitOfWork.Reservations.Add(newReservation);

            await _unitOfWork.SaveChanges();

            return newReservation.Id;
        }

        public Task Delete(int id)
        {
            return _unitOfWork.Reservations.Delete(id);
        }
    }
}

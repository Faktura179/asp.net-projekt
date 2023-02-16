using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using AutoMapper;

namespace Asp.Net_WebApi_projekt.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();

            CreateMap<SwimmingPool, SwimmingPoolDto>();
            CreateMap<SwimmingPoolDto, SwimmingPool>();

            CreateMap<SwimmingTrack, SwimmingTrackDto>();
            CreateMap<SwimmingTrackDto, SwimmingTrack>();
        }
    }
}

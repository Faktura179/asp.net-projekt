using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Models
{
    public class AddReservationVM
    {
        public AddReservationVM()
        {

        }

        public AddReservationVM(List<ClientDto> clients, List<SwimmingTrackDto> swimmingTracks)
        {
            Initialize(clients, swimmingTracks);
        }

        [Required]
        public int ClientId { get; set; }
        [Required]
        public int SwimmingTrackId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [Required]
        public DateTime EndTime { get; set; } = DateTime.Now;

        private List<ClientDto> _clients;
        public List<SelectListItem> ClientsList { 
            get
            {
                if(_clients== null)
                    return new List<SelectListItem>();
                return _clients.Select(x => new SelectListItem($"{x.FirstName} {x.LastName}", x.Id.ToString())).ToList();
            }
        }

        private List<SwimmingTrackDto> _swimmingTracks;
        public List<SelectListItem> SwimmingTracksList 
        { 
            get
            {
                if (_swimmingTracks == null)
                    return new List<SelectListItem>();
                return _swimmingTracks.Select(x => new SelectListItem($"{x.SwimmingPool.Name} - {x.Name}({x.Length}m)", x.Id.ToString())).ToList();
            } 
        }

        public void Initialize(List<ClientDto> clients, List<SwimmingTrackDto> swimmingTracks)
        {
            _clients = clients;
            _swimmingTracks = swimmingTracks;
        }
    }
}

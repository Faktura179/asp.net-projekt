using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class SwimmingTrackVM
    {
        public SwimmingTrackVM(SwimmingTrackDto swimmingTrack)
        {
            SwimmingTrack = swimmingTrack;
        }

        public SwimmingTrackDto SwimmingTrack { get; set; }
    }
}

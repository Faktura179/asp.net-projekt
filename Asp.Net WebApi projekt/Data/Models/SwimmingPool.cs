using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Data.Models
{
    public class SwimmingPool
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string Location { get; set; }

        public IEnumerable<SwimmingTrack> SwimmingTracks { get; set; }
    }
}

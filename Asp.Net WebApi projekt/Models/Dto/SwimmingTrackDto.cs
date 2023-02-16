using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Models.Dto
{
    public class SwimmingTrackDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Capacity { get; set; }
        public int SwimmingPoolId { get; set; }

        public SwimmingPoolDto SwimmingPool { get; set; }
    }
}

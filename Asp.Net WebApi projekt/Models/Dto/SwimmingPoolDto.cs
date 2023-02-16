namespace Asp.Net_WebApi_projekt.Models.Dto
{
    public class SwimmingPoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<SwimmingTrackDto> SwimmingTracks { get; set; }
    }
}

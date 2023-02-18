using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class IndexVm
    {
        public IndexVm(List<SwimmingPoolDto> pools)
        {
            Pools = pools;
        }

        public List<SwimmingPoolDto> Pools { get; set; }
    }
}

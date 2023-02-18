using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class IndexVm
    {
        public IndexVm(List<SwimmingPoolDto> pools, ClientsPartialVM clientsVM)
        {
            Pools = pools;
            ClientsVM = clientsVM;
        }

        public List<SwimmingPoolDto> Pools { get; set; }
        public ClientsPartialVM ClientsVM { get; set; }
    }
}

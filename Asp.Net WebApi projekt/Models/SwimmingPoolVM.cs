using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class SwimmingPoolVM
    {
        public SwimmingPoolVM(SwimmingPoolDto swimmingPool) 
        { 
            SwimmingPool = swimmingPool;
        }

        public SwimmingPoolDto SwimmingPool { get; set; }
    }
}

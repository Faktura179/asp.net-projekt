using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Models
{
    public class AddSwimmingPoolVm
    {
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string Location { get; set; }
    }
}

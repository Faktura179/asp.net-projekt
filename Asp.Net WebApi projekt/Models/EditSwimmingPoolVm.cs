using Asp.Net_WebApi_projekt.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_WebApi_projekt.Models
{
    public class EditSwimmingPoolVm
    {
        public EditSwimmingPoolVm()
        {

        }

        public EditSwimmingPoolVm(SwimmingPoolDto swimmingPool)
        {
            Id = swimmingPool.Id;
            Name = swimmingPool.Name;
            Location = swimmingPool.Location;
        }

        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string Location { get; set; }
    }
}

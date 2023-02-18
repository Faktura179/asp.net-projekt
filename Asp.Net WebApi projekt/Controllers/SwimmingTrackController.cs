using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_WebApi_projekt.Controllers
{
    public class SwimmingTrackController : Controller
    {
        private readonly IReadSwimmingTrackService _readSwimmingTrackService;

        public SwimmingTrackController(IReadSwimmingTrackService readSwimmingTrackService)
        {
            _readSwimmingTrackService = readSwimmingTrackService;
        }

        public async Task<ActionResult> Index(int id)
        {
            SwimmingTrackVM model = new SwimmingTrackVM(await _readSwimmingTrackService.GetById(id));

            return View(model);
        }
    }
}

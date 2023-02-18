using Asp.Net_WebApi_projekt.Models;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asp.Net_WebApi_projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReadClientService _readClientService;
        private readonly IReadSwimmingPoolService _readSwimmingPoolService;

        public HomeController(ILogger<HomeController> logger, 
            IReadClientService readClientService,
            IReadSwimmingPoolService readSwimmingPoolService)
        {
            _logger = logger;
            _readClientService = readClientService;
            _readSwimmingPoolService = readSwimmingPoolService;
        }

        public async Task<IActionResult> Index()
        {
            IndexVm model = new IndexVm(await _readSwimmingPoolService.GetAll());

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
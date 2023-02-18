using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_WebApi_projekt.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReadReservationService _readReservationService;

        public ReservationController(IReadReservationService readReservationService)
        {
            _readReservationService = readReservationService;
        }

        public async Task<ActionResult> Index(int id)
        {
            ReservationVM model = new ReservationVM(await _readReservationService.GetById(id));

            return View(model);
        }

    }
}

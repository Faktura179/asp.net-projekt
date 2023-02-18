using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Models;
using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_WebApi_projekt.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReadReservationService _readReservationService;
        private readonly IWriteReservationService _writeReservationService;
        private readonly IReadClientService _readClientService;
        private readonly IReadSwimmingTrackService _readSwimmingTrackService;

        public ReservationController(IReadReservationService readReservationService, IReadClientService readClientService, IReadSwimmingTrackService readSwimmingTrackService, IWriteReservationService writeReservationService)
        {
            _readReservationService = readReservationService;
            _readClientService = readClientService;
            _readSwimmingTrackService = readSwimmingTrackService;
            _writeReservationService = writeReservationService;
        }

        public async Task<ActionResult> Index(int id)
        {
            ReservationVM model = new ReservationVM(await _readReservationService.GetById(id));

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> Add()
        {
            AddReservationVM model = new AddReservationVM(await _readClientService.GetAll(), await _readSwimmingTrackService.GetAll()); ;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add(AddReservationVM model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newId = await _writeReservationService.Add(new ReservationDto()
                    {
                        ClientId = model.ClientId,
                        Price = model.Price,
                        SwimmingTrackId = model.SwimmingTrackId,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                    });

                    return RedirectToAction("Index", new { Id = newId });
                }
                catch (ArgumentException e)
                {
                    ModelState.AddModelError(nameof(model.StartTime), "Invalid date");
                    ModelState.AddModelError(nameof(model.EndTime), "Invalid date");
                }
            }

            model.Initialize(await _readClientService.GetAll(), await _readSwimmingTrackService.GetAll());

            return View(model);
        }

        [HttpDelete]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _writeReservationService.Delete(Id);

            return Ok();
        }
    }
}

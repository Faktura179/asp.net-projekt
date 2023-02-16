using Asp.Net_WebApi_projekt.Models;
using Asp.Net_WebApi_projekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class SwimmingPoolController : Controller
    {
        private readonly IWriteSwimmingPoolService _writeSwimmingPoolService;
        private readonly IReadSwimmingPoolService _readSwimmingPoolService;

        public SwimmingPoolController(IWriteSwimmingPoolService writeSwimmingPoolService, IReadSwimmingPoolService readSwimmingPoolService)
        {
            _writeSwimmingPoolService = writeSwimmingPoolService;
            _readSwimmingPoolService = readSwimmingPoolService;
        }

        public IActionResult Add()
        {
            AddSwimmingPoolVm model = new AddSwimmingPoolVm();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddSwimmingPoolVm model)
        {
            if (ModelState.IsValid)
            {
                int newItemId = await _writeSwimmingPoolService.Create(new Models.Dto.SwimmingPoolDto()
                {
                    Location = model.Location,
                    Name = model.Name,
                });

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            EditSwimmingPoolVm model = new EditSwimmingPoolVm(await _readSwimmingPoolService.GetById(id));

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditSwimmingPoolVm model)
        {
            if (ModelState.IsValid)
            {
                await _writeSwimmingPoolService.Update(new Models.Dto.SwimmingPoolDto()
                {
                    Id = model.Id,
                    Location = model.Location,
                    Name = model.Name,
                });

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}

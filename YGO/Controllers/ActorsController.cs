using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Data;
using YGO.Data.Services;
using YGO.Models;

namespace YGO.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService service;

        public ActorsController(IActorsService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> index()
        {
            var result = await service.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (result == null) return View("NotFound");

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (result == null) return View("NotFound");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (result == null) return View("NotFound");

            return View(result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (result == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;
using eTicketBooking.Models.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicketBooking.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasSvc;
        private readonly IValidator<Cinema> _cinemaValidator;

        public CinemasController(ICinemasService cinemasSvc)
        {
            _cinemasSvc = cinemasSvc;
            _cinemaValidator = new CinemaValidator();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _cinemasSvc.GetAllAsync();

            return View(allCinemas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoURL,Name,Address,Description")] Cinema cinema)
        {
            var validatinResults = _cinemaValidator.Validate(cinema);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(cinema);
            }

            await _cinemasSvc.CreateAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemasSvc.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemasSvc.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,LogoURL,Name,Address,Description")] int id, Cinema cinema)
        {
            var validatinResults = _cinemaValidator.Validate(cinema);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(cinema);
            }

            await _cinemasSvc.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemasSvc.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _cinemasSvc.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            await _cinemasSvc.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;
using eTicketBooking.Models.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicketBooking.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersSvc;
        private readonly IValidator<Producer> _producerValidator;

        public ProducersController(IProducersService producersSvc)
        {
            _producersSvc = producersSvc;
            _producerValidator = new ProducerValidator();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _producersSvc.GetAllAsync();

            return View(allProducers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            var validatinResults = _producerValidator.Validate(producer);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(producer);
            }

            await _producersSvc.CreateAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producersSvc.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producersSvc.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            var validatinResults = _producerValidator.Validate(producer);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(producer);
            }

            await _producersSvc.UpdateAsync(id, producer);

            return View(producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producersSvc.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _producersSvc.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            await _producersSvc.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;
using eTicketBooking.Models.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicketBooking.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsSvc;
        private readonly IValidator<Actor> _actorValidator;

        public ActorsController(IActorsService actorsSvc)
        {
            _actorsSvc = actorsSvc;
            _actorValidator = new ActorValidator();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _actorsSvc.GetAllAsync();

            return View(allActors);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            var validationResult = _actorValidator.Validate(actor);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(actor);
            }

            await _actorsSvc.CreateAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsSvc.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsSvc.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePictureURL,Bio")] int id, Actor actor)
        {
            var validationResult = _actorValidator.Validate(actor);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(actor);
            }

            await _actorsSvc.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsSvc.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorsSvc.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            await _actorsSvc.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
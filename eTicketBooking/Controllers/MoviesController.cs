using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models.Validators.ViewModels;
using eTicketBooking.Models.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTicketBooking.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesSvc;
        private readonly IValidator<NewMovieVM> _movieValidator;

        public MoviesController(IMoviesService moviesSvc)
        {
            _moviesSvc = moviesSvc;
            _movieValidator = new NewMovieVMValidator();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _moviesSvc.GetAllAsync();

            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _moviesSvc.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredMovies = allMovies.Where(
                    m => m.Name.Contains(searchString.ToLower()) ||
                    m.Description.Contains(searchString.ToLower()))
                 .ToList();

                return View(nameof(Index), filteredMovies);
            }

            return View("Index", allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _moviesSvc.GetMovieByIdAsync(id);

            return View(movieDetails);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _moviesSvc.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM data)
        {
            var validatinResults = _movieValidator.Validate(data);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var movieDropdownData = await _moviesSvc.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "FullName");

                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(data);
            }

            await _moviesSvc.AddNewMovieAsync(data);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesSvc.GetMovieByIdAsync(id);

            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(a => a.ActorId).ToList()
            };

            var movieDropdownData = await _moviesSvc.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM data)
        {
            if (id != data.Id) return View("NotFound");

            var validatinResults = _movieValidator.Validate(data);

            if (!validatinResults.IsValid)
            {
                foreach (var error in validatinResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var movieDropdownData = await _moviesSvc.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(data);
            }

            await _moviesSvc.UpdateMovieAsync(data);

            return RedirectToAction(nameof(Index));
        }
    }
}
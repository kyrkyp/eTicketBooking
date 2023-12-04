using System.Security.Claims;
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models.ViewModels;
using eTickets.Data.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicketBooking.Controllers
{
    [Authorize]
    public class OrdesController : Controller
    {
        private readonly IMoviesService _moviesSvc;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersSvc;

        public OrdesController(
            IMoviesService moviesSvc,
            ShoppingCart shoppingCart,
            IOrdersService ordersSvc)
        {
            _moviesSvc = moviesSvc;
            _shoppingCart = shoppingCart;
            _ordersSvc = ordersSvc;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersSvc.GetOrdersByUserIdAndRoleAsync(userId, userRole);

            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var selectedMovie = await _moviesSvc.GetMovieByIdAsync(id);

            if (selectedMovie != null)
            {
                _shoppingCart.AddItemToCart(selectedMovie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedMovie = await _moviesSvc.GetMovieByIdAsync(id);

            if (selectedMovie != null)
            {
                _shoppingCart.RemoveItemFromCart(selectedMovie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var selectedMovies = _shoppingCart.GetShoppingCartItems();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            await _ordersSvc.StoreOrderAsync(selectedMovies, userId, userEmail);

            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
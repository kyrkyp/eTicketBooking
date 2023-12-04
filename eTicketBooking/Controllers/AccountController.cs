using eTicketBooking.Data;
using eTicketBooking.Models.Registry;
using eTicketBooking.Models.Registry.Static;
using eTicketBooking.Models.Validators.ViewModels;
using eTicketBooking.Models.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IValidator<LoginVM> _loginValidator;
        private readonly IValidator<RegisterVM> _registerValidator;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _loginValidator = new LoginVMValidator();
            _registerValidator = new RegisterVMValidator();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();

            return View(users);
        }

        #region Login

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var validationResult = await _loginValidator.ValidateAsync(loginVM);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";

                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";

            return View(loginVM);
        }

        #endregion Login

        #region Register

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var validationResult = await _registerValidator.ValidateAsync(registerVM);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

        #endregion Register

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
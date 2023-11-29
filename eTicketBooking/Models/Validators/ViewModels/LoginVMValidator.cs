using eTicketBooking.Models.ViewModels;
using FluentValidation;

namespace eTicketBooking.Models.Validators.ViewModels
{
    public class LoginVMValidator : AbstractValidator<LoginVM>
    {
        public LoginVMValidator()
        {
            RuleFor(l => l.EmailAddress)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email address is required")
                .EmailAddress()
                .WithMessage("Email address is not valid");

            RuleFor(l => l.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long");
        }
    }
}
using eTicketBooking.Models.ViewModels;
using FluentValidation;

namespace eTicketBooking.Models.Validators.ViewModels
{
    public class RegisterVMValidator : AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(r => r.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Full name is required")
                .MinimumLength(6)
                .WithMessage("Full name must be at least 6 characters long");

            RuleFor(r => r.EmailAddress)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email address is required")
                .EmailAddress()
                .WithMessage("Email address is not valid");

            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long");

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage("Confirm password is required")
                .Equal(r => r.Password)
                .WithMessage("Confirm password must match password");
        }
    }
}
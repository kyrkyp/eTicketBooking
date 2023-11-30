using FluentValidation;

namespace eTicketBooking.Models.Validators
{
    public class CinemaValidator : AbstractValidator<Cinema>
    {
        public CinemaValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Cinema name is required.")
                .MaximumLength(50)
                .WithMessage("Cinema name cannot be longer than 50 characters.");

            RuleFor(c => c.Address)
                .NotEmpty()
                .WithMessage("Cinema address is required.")
                .MaximumLength(100)
                .WithMessage("Cinema address cannot be longer than 100 characters.");

            RuleFor(c => c.LogoURL)
                .NotEmpty()
                .WithMessage("Cinema logo is required.")
                .MaximumLength(200)
                .WithMessage("Cinema logo URL cannot be longer than 200 characters.");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Cinema description is required.")
                .MaximumLength(500)
                .WithMessage("Cinema description cannot be longer than 500 characters.");
        }
    }
}
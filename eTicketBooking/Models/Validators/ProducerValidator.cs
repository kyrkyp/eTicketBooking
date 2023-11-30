using FluentValidation;

namespace eTicketBooking.Models.Validators
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                .WithMessage("Producer name is required.")
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Producer name must be between 3 and 50 characters.");

            RuleFor(p => p.Bio)
                .NotEmpty()
                .WithMessage("Producer biography is required.")
                .MaximumLength(100)
                .WithMessage("Producer biography cannot be longer than 100 characters.");

            RuleFor(p => p.ProfilePictureURL)
                .NotEmpty()
                .WithMessage("Producer logo URL is required.");
        }
    }
}
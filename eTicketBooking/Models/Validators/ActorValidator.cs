using FluentValidation;

namespace eTicketBooking.Models.Validators
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Full name is required")
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("Full name must be between 3 and 50 characters long!");

            RuleFor(a => a.Bio)
                .NotEmpty()
                .NotNull()
                .WithMessage("Biography is required")
                .MaximumLength(300)
                .WithMessage("Biography cannot be longer than 500 characters");

            RuleFor(a => a.ProfilePictureURL)
                .NotEmpty()
                .NotNull()
                .WithMessage("Profile picture URL is required");
        }
    }
}
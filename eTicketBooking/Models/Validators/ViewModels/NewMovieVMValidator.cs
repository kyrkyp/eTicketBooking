using eTicketBooking.Models.ViewModels;
using FluentValidation;

namespace eTicketBooking.Models.Validators.ViewModels
{
    public class NewMovieVMValidator : AbstractValidator<NewMovieVM>
    {
        public NewMovieVMValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie name is required");

            RuleFor(m => m.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie description is required");

            RuleFor(m => m.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie price is required");

            RuleFor(m => m.ImageURL)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie poster URL is required");

            RuleFor(m => m.StartDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie start date is required");

            RuleFor(m => m.EndDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie end date is required");

            RuleFor(m => m.MovieCategory)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie category is required");

            RuleFor(m => m.ActorIds)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie actor(s) is required");

            RuleFor(m => m.CinemaId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie cinema is required");

            RuleFor(m => m.ProducerId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Movie producer is required");
        }
    }
}
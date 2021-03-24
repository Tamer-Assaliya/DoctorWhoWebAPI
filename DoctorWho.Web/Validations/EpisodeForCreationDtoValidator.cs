using System;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class EpisodeForCreationDtoValidator : AbstractValidator<Models.EpisodeForCreationDto>
    {
        public EpisodeForCreationDtoValidator()
        {
            RuleFor(e => e.AuthorId).NotNull();
            RuleFor(e => e.DoctorId).NotNull();
            // RuleFor(e => e.SeriesNumber).Length(10); //SeriesNumber should be defined as string to apply this
            RuleFor(e => e.EpisodeNumber).GreaterThan(0);
        }
    }
}
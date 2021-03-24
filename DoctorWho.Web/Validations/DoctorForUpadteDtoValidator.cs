using System;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForUpdateDtoValidator : AbstractValidator<Models.DoctorForUpadteDto>
    {
        public DoctorForUpdateDtoValidator()
        {
            RuleFor(d => d.DoctorName).NotNull();
            RuleFor(d => d.DoctorNumber).NotNull();
            RuleFor(d => d.LastEpisodeDate).Null().When(d => d.FirstEpisodeDate == null);
            RuleFor(d => d.LastEpisodeDate).GreaterThanOrEqualTo(d => d.FirstEpisodeDate).When(d => d.LastEpisodeDate != null);
        }
    }
}
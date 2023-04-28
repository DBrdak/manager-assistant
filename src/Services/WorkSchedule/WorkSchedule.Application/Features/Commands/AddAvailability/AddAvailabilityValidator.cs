using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using WorkSchedule.Domain.Common;

namespace WorkSchedule.Application.Features.Month.Commands.AddAvailability
{
    public sealed class AddAvailabilityValidator : AbstractValidator<AddAvailabilityCommand>
    {
        public AddAvailabilityValidator()
        {
            RuleFor(x => x.Availability)
                .Must(a => Regex.IsMatch(a.EndHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
                           && Regex.IsMatch(a.StartHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
                .WithMessage("Wrong time format")
                .Must(a => new Time(a.StartHour) < new Time(a.EndHour))
                .WithMessage("Start and end time conflict");
        }
    }
}

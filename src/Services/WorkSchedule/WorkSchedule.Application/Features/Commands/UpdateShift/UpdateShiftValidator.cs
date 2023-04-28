using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using WorkSchedule.Domain.Common;

namespace WorkSchedule.Application.Features.Month.Commands.UpdateAvailability
{
    public class UpdateShiftValidator : AbstractValidator<UpdateShiftCommand>
    {
        public UpdateShiftValidator()
        {
            RuleFor(x => x.Shift)
                .Must(s => Regex.IsMatch(s.EndHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
                           && Regex.IsMatch(s.StartHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
                .WithMessage("Wrong time format")
                .Must(a => new Time(a.StartHour) < new Time(a.EndHour))
                .WithMessage("Start and end time conflict");
        }
    }
}

using System.Text.RegularExpressions;
using System.Xml.XPath;
using FluentValidation;
using WorkSchedule.Application.Core;
using WorkSchedule.Application.Core.GlobalValidators;
using WorkSchedule.Application.Features.Month.Commands.PrepareSchedule;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Entities;

namespace WorkSchedule.Application.Features.Commands.PrepareSchedule;

public class PrepareScheduleValidator : AbstractValidator<PrepareScheduleRequest>
{
    public PrepareScheduleValidator()
    {
        RuleForEach(x => x.Schedule.WorkingDays)
            .Must(wd => !wd.Shifts.Any())
            .WithMessage("You can't add shifts at this step")
            .Must(wd => Regex.IsMatch(wd.OpenHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
                        && Regex.IsMatch(wd.CloseHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
            .WithMessage($"Wrong hour specified")
            .Must(wd => new Time(wd.CloseHour) > new Time(wd.OpenHour))
            .WithMessage("Open close time conflict");

        RuleFor(x => x.Schedule).Must(x =>
            !x.WorkingDays.Select(wd => wd.Date >= x.MonthStartDate && wd.Date <= x.MonthEndDate).Any(b => b == false));

        RuleFor(x => x.Schedule.MonthName).SetValidator(new MonthValidator());
    }
}
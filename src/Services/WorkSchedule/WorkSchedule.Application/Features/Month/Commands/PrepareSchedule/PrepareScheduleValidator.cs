using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.XPath;
using FluentValidation;

namespace WorkSchedule.Application.Features.Month.Commands.PrepareSchedule
{
    public class PrepareScheduleValidator : AbstractValidator<PrepareScheduleRequest>
    {
        public PrepareScheduleValidator()
        {
            RuleForEach(x => x.WorkingDays)
                .Must(wd => !wd.Shifts.Any())
                .WithMessage("You can't add shifts at this step")
                .Must(wd => Regex.IsMatch(wd.OpenHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
                            && Regex.IsMatch(wd.CloseHour, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
                .WithMessage($"Wrong hour specified");
        }
    }
}

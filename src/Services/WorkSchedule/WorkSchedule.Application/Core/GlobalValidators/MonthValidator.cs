using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FluentValidation;

namespace WorkSchedule.Application.Core.GlobalValidators
{
    public class MonthValidator : AbstractValidator<string>
    {
        private static readonly List<string> _months = new(){
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        public MonthValidator()
        {
            RuleFor(x => x)
                .Must(s => _months.Any(m => m == s))
                .WithMessage("Invalid month");
        }
    }
}

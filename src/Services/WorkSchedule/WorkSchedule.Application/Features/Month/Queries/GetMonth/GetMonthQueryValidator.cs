using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace WorkSchedule.Application.Features.Month.Queries.GetMonth
{
    public class GetMonthQueryValidator : AbstractValidator<GetMonthQuery>
    {
        public GetMonthQueryValidator()
        {
            RuleFor(x => x.Month)
                .Must(m => months.Any(x => x == m))
                .WithMessage("Wrong month specified");
        }

        private readonly string[] months = {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };
    }
}

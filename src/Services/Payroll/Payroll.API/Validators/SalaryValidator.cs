using FluentValidation;
using Payroll.API.Entities;

namespace Payroll.API.Validators
{
    public class SalaryValidator : AbstractValidator<Salary>
    {
        public SalaryValidator()
        {
            RuleFor(s => s)
                .Must(s => s.Hours > 0)
                .WithMessage("Hour count should be positive")
                .Must(s => s.PeriodPaid.From < s.PeriodPaid.To)
                .WithMessage("Invalid payment period")
                .Must(s => s.Wage > 0)
                .WithMessage("Wage must be positive");

            RuleFor(s => s.EmployeeFinancialData.Email).EmailAddress();
            RuleFor(s => s.EmployeeFinancialData.Phone).Matches(
                "^\\+?[0-9]{1,3}?[-.\\s]?\\(?\\d{1,3}\\)?[-.\\s]?\\d{3,4}[-.\\s]?\\d{4}$");
            RuleFor(s => s.EmployeeFinancialData.IBAN).Matches(
                /* Regex that checks if iban is specified well, including country code check */
                "^(AD|AE|AL|AT|AZ|BA|BE|BG|BH|BR|BY|CH|CR|CY|CZ|DE|DK|DO|EE|ES|FI|FO|FR|GB|GE|GI|GL|GR|GT|HR|HU|IE|IL|IQ|IS|IT|JO|KW|KZ|LB|LI|LT|LU|LV|MC|MD|ME|MK|MR|MT|MU|NL|NO|PK|PL|PS|PT|QA|RO|RS|SA|SE|SI|SK|SM|TN|TR|UA|VA|VG)(\\d{2})([a-zA-Z0-9]{1,30})$")
                .WithMessage("Invalid IBAN");
            RuleFor(S => S.EmployeeFinancialData.SWIFT).Matches(
                "^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")
                .WithMessage("Invalid swift code");

        }
    }
}

using FluentValidation;

namespace Employee.API.Validators
{
    public class EmployeeValidator : AbstractValidator<Entities.Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.UniqueName)
                .Must(n => n.Length < 25)
                .WithMessage("Name of employee should be shorter than 25 characters")
                .Must(n => n.Select(char.IsLetterOrDigit).All(r => r))
                .WithMessage("Name can only contain letters and digits");

            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.Phone).Matches(
                "^\\+?[0-9]{1,3}?[-.\\s]?\\(?\\d{1,3}\\)?[-.\\s]?\\d{3,4}[-.\\s]?\\d{4}$");
            RuleFor(e => e.IBAN).Matches(
                    /* Regex that checks if iban is specified well, including country code check */
                    "^(AD|AE|AL|AT|AZ|BA|BE|BG|BH|BR|BY|CH|CR|CY|CZ|DE|DK|DO|EE|ES|FI|FO|FR|GB|GE|GI|GL|GR|GT|HR|HU|IE|IL|IQ|IS|IT|JO|KW|KZ|LB|LI|LT|LU|LV|MC|MD|ME|MK|MR|MT|MU|NL|NO|PK|PL|PS|PT|QA|RO|RS|SA|SE|SI|SK|SM|TN|TR|UA|VA|VG)(\\d{2})([a-zA-Z0-9]{1,30})$\r\n")
                .WithMessage("Invalid IBAN");
            RuleFor(e => e.SWIFT).Matches(
                    "^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")
                .WithMessage("Invalid swift code");
        }
    }
}

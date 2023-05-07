using FluentValidation;
using WorkTimeTracker.Grpc.Protos;

namespace WorkTimeTracker.Grpc.Validators
{
    public class CompletedShiftPostModelValidator : AbstractValidator<CompletedShiftPostModel>
    {
        public CompletedShiftPostModelValidator()
        {
            RuleFor(x => x.StartTime)
                .Matches("^(\\d{4})-(\\d{2})-(\\d{2})T(\\d{2}):(\\d{2}):(\\d{2})\\.(\\d{7})Z$")
                .WithMessage("Invalid start date format");

            RuleFor(x => x.EndTime)
                .Matches("^(\\d{4})-(\\d{2})-(\\d{2})T(\\d{2}):(\\d{2}):(\\d{2})\\.(\\d{7})Z$")
                .WithMessage("Invalid end date format");
        }
    }
}

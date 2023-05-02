using FluentValidation;
using WorkTimeTracker.Grpc.Entities;

namespace WorkTimeTracker.Grpc.Validators
{
    public class CompletedShiftValidator : AbstractValidator<CompletedShift>
    {
        public CompletedShiftValidator()
        {
            RuleFor(cs => cs)
                .Must(cs => cs.ShiftStart < cs.ShiftEnd)
                .WithMessage("Invalid start and end time");
        }
    }
}

using WorkTimeTracker.API.Entities;

namespace WorkTimeTracker.API.Repositories
{
    public interface IWorkTimeTrackerRepository
    {
        Task<IEnumerable<CompletedShift>> GetByEmployee(string employeeName);
        Task AddCompletedShift(CompletedShift completedShift);
        Task<bool> SetAsPaid(string completedShiftId);
        Task<bool> RemoveCompletedShift(string completedShiftId);
    }
}

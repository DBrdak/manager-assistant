using WorkTimeTracker.Grpc.Entities;

namespace WorkTimeTracker.Grpc.Repositories
{
    public interface IWorkTimeTrackerRepository
    {
        Task<IEnumerable<CompletedShift>> GetByEmployee(string employeeName);
        Task AddCompletedShift(CompletedShift completedShift);
        Task<bool> SetAsPaid(string completedShiftId);
        Task<bool> RemoveCompletedShift(string completedShiftId);
    }
}

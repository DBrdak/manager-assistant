using MongoDB.Driver;
using WorkTimeTracker.Grpc.Entities;

namespace WorkTimeTracker.Grpc.Data
{
    public interface IWorkTimeTrackerContext
    {
        public IMongoCollection<CompletedShift> CompletedShifts { get; set; }
    }
}

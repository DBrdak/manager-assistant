using MongoDB.Driver;
using WorkTimeTracker.API.Entities;

namespace WorkTimeTracker.API.Data
{
    public interface IWorkTimeTrackerContext
    {
        public IMongoCollection<CompletedShift> CompletedShifts { get; set; }
    }
}

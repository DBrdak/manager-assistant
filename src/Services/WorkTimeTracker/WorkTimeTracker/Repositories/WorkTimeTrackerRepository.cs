using MongoDB.Driver;
using WorkTimeTracker.API.Data;
using WorkTimeTracker.API.Entities;

namespace WorkTimeTracker.API.Repositories
{
    public class WorkTimeTrackerRepository : IWorkTimeTrackerRepository
    {
        private readonly IWorkTimeTrackerContext _context;

        public WorkTimeTrackerRepository(IWorkTimeTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompletedShift>> GetByEmployee(string employeeName)
            => await _context.CompletedShifts.Find(cs => cs.EmployeeName == employeeName).ToListAsync();

        public async Task AddCompletedShift(CompletedShift completedShift) =>
            await _context.CompletedShifts.InsertOneAsync(completedShift);

        public async Task<bool> SetAsPaid(string completedShiftId)
        {
            var filter = Builders<CompletedShift>.Filter.Eq("Id", completedShiftId);
            var update = Builders<CompletedShift>.Update.Combine(
                Builders<CompletedShift>.Update.Set("IsPaid", true),
                Builders<CompletedShift>.Update.Set("ExpiryDate", DateTime.Now.AddDays(3))
            );

            var result = await _context.CompletedShifts.UpdateOneAsync(filter, update);

            return result.IsAcknowledged &&
                   result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveCompletedShift(string completedShiftId)
        {
            var result = await _context.CompletedShifts.DeleteOneAsync(cs => cs.Id == completedShiftId);

            return result.IsAcknowledged &&
                   result.DeletedCount > 0;
        }
    }
}

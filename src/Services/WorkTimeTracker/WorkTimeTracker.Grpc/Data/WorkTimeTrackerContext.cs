using MongoDB.Driver;
using WorkTimeTracker.Grpc.Entities;

namespace WorkTimeTracker.Grpc.Data
{
    public class WorkTimeTrackerContext : IWorkTimeTrackerContext
    {
        public IMongoCollection<CompletedShift> CompletedShifts { get; set; }

        public WorkTimeTrackerContext(IConfiguration config)
        {
            var client = new MongoClient(
                config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(
                config.GetValue<string>("DatabaseSettings:DatabaseName"));

            CompletedShifts = database.GetCollection<CompletedShift>(
                config.GetValue<string>("DatabaseSettings:CollectionName"));

            var indexKeysDefinition = Builders<CompletedShift>.IndexKeys.Ascending(x => x.ExpiryDate);
            var indexModel = new CreateIndexModel<CompletedShift>(indexKeysDefinition);
            CompletedShifts.Indexes.CreateOne(indexModel);
            CompletedShifts.Seed();
        }
    }
}

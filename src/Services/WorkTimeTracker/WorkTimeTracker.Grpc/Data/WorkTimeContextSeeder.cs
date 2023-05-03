using MongoDB.Driver;
using WorkTimeTracker.Grpc.Entities;

public static class WorkTimeContextSeeder
{
    public static void Seed(this IMongoCollection<CompletedShift> data)
    {
        if (data.Find(e => true).Any())
            return;

        var completedShifts = new List<CompletedShift>
        {
            new CompletedShift("Adam", new DateTime(2023, 1, 15, 8, 0, 0), new DateTime(2023, 1, 15, 14, 0, 0)),
            new CompletedShift("Emily", new DateTime(2023, 1, 15, 12, 0, 0), new DateTime(2023, 1, 15, 20, 0, 0)),
            new CompletedShift("David", new DateTime(2023, 1, 15, 16, 0, 0), new DateTime(2023, 1, 15, 21, 30, 0)),
            new CompletedShift("Sarah", new DateTime(2023, 1, 15, 20, 0, 0), new DateTime(2023, 1, 16, 0, 0, 0)),
        };

        data.InsertMany(completedShifts);
    }
}
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
            new CompletedShift("Adam", DateTime.Now.AddDays(-2).AddHours(-14), DateTime.Now.AddDays(-2).AddHours(-8)),
            new CompletedShift("Emily", DateTime.Now.AddDays(-2).AddHours(-20), DateTime.Now.AddDays(-2).AddHours(-12)),
            new CompletedShift("David", DateTime.Now.AddDays(-2).AddHours(-20), DateTime.Now.AddDays(-2).AddHours(-14)),
            new CompletedShift("Sarah", DateTime.Now.AddDays(-2).AddHours(-24), DateTime.Now.AddDays(-2).AddHours(-16)),
        };

        data.InsertMany(completedShifts);
    }
}
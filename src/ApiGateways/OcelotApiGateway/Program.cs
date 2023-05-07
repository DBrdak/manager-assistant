
using Ocelot.Middleware;
using OcelotApiGateway.Extensions;

namespace OcelotApiGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.ConfigureBuilder();

            var app = builder.Build();

            app.UseRouting();

            await app.UseOcelot();
            await app.RunAsync();
        }
    }
}
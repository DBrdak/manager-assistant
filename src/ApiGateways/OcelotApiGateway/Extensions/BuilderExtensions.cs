using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;

namespace OcelotApiGateway.Extensions
{
    public static class BuilderExtensions
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            builder.Services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());

            builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
                config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true));

            return builder;
        }
    }
}

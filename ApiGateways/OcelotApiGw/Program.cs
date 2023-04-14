using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Logging.AddConfiguration(configuration.GetSection("Logging")).AddConsole().AddDebug().AddEventSourceLogger();

//IConfiguration configuration2 = new ConfigurationBuilder()
//                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
//                            .Build();

//builder.Services.AddOcelot(configuration2);

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");


app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqliteConsole.Infrastructure.Data;
using SqliteConsole.Infrastructure.Services;

namespace Db1Console;

internal class Program
{
    private static ServiceProvider services;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //var builder = Host.CreateApplicationBuilder(args);

        initialize(args);

        // Example Service
        var service = services.GetService<IDocService>();
        service?.AddDoc("test1");
        service?.GetDocs();
    }

    static void initialize(string[] args)
    {
        // Configuration
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();

        // Database
        var optionsBuilder = new DbContextOptionsBuilder<Database1Context>()
            .UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        var context = new Database1Context(optionsBuilder.Options);
        context.Database.EnsureCreated();

        // Services
        services = new ServiceCollection()
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            })
            .AddSingleton(configuration)
            .AddSingleton(optionsBuilder.Options)
            .AddSingleton<IDocService, DocService>()
            //.AddDbContextPool<Database1Context>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")))
            .AddDbContext<Database1Context>()
            .BuildServiceProvider();

        var logger = (services.GetService<ILoggerFactory>() ?? throw new InvalidOperationException())
            .CreateLogger<Program>();

        logger.LogInformation($"Starting application at: {DateTime.Now}");


    }
}

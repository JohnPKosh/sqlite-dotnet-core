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
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var builder = Host.CreateApplicationBuilder(args);
    }
}

using Microsoft.EntityFrameworkCore;
using SqliteConsole.Core.Entities;

namespace SqliteConsole.Infrastructure.Data
{

    /// <summary>
    /// Entity framework context
    /// </summary>
    public class SqliteConsoleContext : DbContext
    {
        public SqliteConsoleContext(DbContextOptions<SqliteConsoleContext> options)
            : base(options)
        { }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Example>()
                .Property(e => e.Name)
                .HasColumnType("varchar(512)");
        }
    }

    public static class SqliteConsoleContextFactory
    {
        public static SqliteConsoleContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqliteConsoleContext>();
            optionsBuilder.UseSqlite(connectionString);

            var context = new SqliteConsoleContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}

/*
Data Types:
https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/types
https://www.sqlite.org/datatype3.html

Visual Studio Package Manager EF Core tools:
https://learn.microsoft.com/en-us/ef/core/cli/powershell

dotnet CLI EF Core tools:
https://learn.microsoft.com/en-us/ef/core/cli/dotnet

package refs:

    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="7.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite.Core" Version="7.0.1" />

dotnet scaffold existing:
cd D:\devhome\ghub\misc\sqlite-dotnet-core\SqliteConsole.Infrastructure
dotnet ef dbcontext scaffold "Data Source=C:\junk\sqlite-data\test.db;" Microsoft.EntityFrameworkCore.Sqlite -o Models

SQLite AUTOINCREMENT:
https://www.sqlite.org/autoinc.html

	"Id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,

*/
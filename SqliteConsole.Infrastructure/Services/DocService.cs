namespace SqliteConsole.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SqliteConsole.Infrastructure.Data;
using SqliteConsole.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DocService : IDocService
{
    private readonly IConfigurationRoot config;
    private readonly ILogger<IDocService> logger;
    private readonly Database1Context context;

    public DocService(ILoggerFactory loggerFactory, IConfigurationRoot configurationRoot, Database1Context dbContext)
    {
        logger = loggerFactory.CreateLogger<DocService>();
        config = configurationRoot;
        context = dbContext;
    }

    public void GetDocs()
    {
        logger.LogInformation($"All examples from database: {config["ConnectionStrings:DefaultConnection"]}");

        var examples = context.DocData
            .OrderBy(e => e.Id)
            .ToList();

        foreach (var example in examples)
        {
            logger.LogInformation($"Name: {example.Guid}");
        }
    }

    public void AddDoc(string name)
    {
        logger.LogInformation($"Adding example: {name}");

        var example = new DocDatum()
        {
            Guid = Guid.NewGuid().ToString(),
            DocType = "test-form",
            DataType = "json",
            CreateUtc = DateTimeOffset.UtcNow,
            CreateTs = 1223444,
            Header = "{ header:{}}",
            Data = "{ data:{}}",
            Tags = "test demo",
            Filed = false
        };

        context.DocData.Add(example);
        context.SaveChanges();
    }
}

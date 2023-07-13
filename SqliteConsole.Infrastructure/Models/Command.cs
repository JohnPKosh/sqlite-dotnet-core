using System;
using System.Collections.Generic;

namespace SqliteConsole.Infrastructure.Models;

public partial class Command
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string CommandPath { get; set; } = null!;

    public string CommandArgs { get; set; } = null!;
}

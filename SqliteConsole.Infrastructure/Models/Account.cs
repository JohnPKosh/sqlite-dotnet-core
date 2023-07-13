﻿using System;
using System.Collections.Generic;

namespace SqliteConsole.Infrastructure.Models;

public partial class Account
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }
}

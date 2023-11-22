using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Table("DocItemEgressLog")]
public partial class DocItemEgressLog
{
    [Key]
    public int Id { get; set; }

    public int DocItemId { get; set; }

    public long SyncTs { get; set; }

    public bool Filed { get; set; }

    [ForeignKey("DocItemId")]
    [InverseProperty("DocItemEgressLogs")]
    public virtual DocItem DocItem { get; set; } = null!;
}

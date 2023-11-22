using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Table("DocDataEgressLog")]
public partial class DocDataEgressLog
{
    [Key]
    public int Id { get; set; }

    public int DocId { get; set; }

    public long SyncTs { get; set; }

    public bool Filed { get; set; }

    [ForeignKey("DocId")]
    [InverseProperty("DocDataEgressLogs")]
    public virtual DocDatum Doc { get; set; } = null!;
}

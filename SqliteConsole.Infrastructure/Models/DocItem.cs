using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Table("DocItem")]
[Index("ItemType", "CreateTs", "DataType", "Guid", Name = "IDX_DocItem_Covering")]
[Index("Guid", Name = "IDX_DocItem_Guid")]
public partial class DocItem
{
    [Key]
    public int Id { get; set; }

    public int DocId { get; set; }

    [StringLength(36)]
    public string Guid { get; set; } = null!;

    [StringLength(50)]
    public string ItemType { get; set; } = null!;

    public DateTimeOffset CreateUtc { get; set; }

    public long CreateTs { get; set; }

    public string Header { get; set; } = null!;

    public string Data { get; set; } = null!;

    [StringLength(8)]
    public string DataType { get; set; } = null!;

    [StringLength(100)]
    public string? Tags { get; set; }

    public bool Filed { get; set; }

    [ForeignKey("DocId")]
    [InverseProperty("DocItems")]
    public virtual DocDatum Doc { get; set; } = null!;

    [InverseProperty("DocItem")]
    public virtual ICollection<DocItemEgressLog> DocItemEgressLogs { get; set; } = new List<DocItemEgressLog>();
}

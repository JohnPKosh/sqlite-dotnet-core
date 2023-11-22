using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Index("DocType", "CreateTs", "DataType", "Guid", Name = "IDX_DocData_Covering")]
[Index("Guid", Name = "IDX_DocData_Guid")]
public partial class DocDatum
{
    [Key]
    public int Id { get; set; }

    [StringLength(36)]
    public string Guid { get; set; } = null!;

    [StringLength(50)]
    public string DocType { get; set; } = null!;

    public DateTimeOffset CreateUtc { get; set; }

    public long CreateTs { get; set; }

    public string Header { get; set; } = null!;

    public string Data { get; set; } = null!;

    [StringLength(8)]
    public string DataType { get; set; } = null!;

    [StringLength(100)]
    public string? Tags { get; set; }

    public bool Filed { get; set; }

    [InverseProperty("Doc")]
    public virtual ICollection<DocDataEgressLog> DocDataEgressLogs { get; set; } = new List<DocDataEgressLog>();

    [InverseProperty("Doc")]
    public virtual ICollection<DocDataTagIdx> DocDataTagIdxes { get; set; } = new List<DocDataTagIdx>();

    [InverseProperty("Doc")]
    public virtual ICollection<DocItem> DocItems { get; set; } = new List<DocItem>();

    [InverseProperty("Doc")]
    public virtual ICollection<DocRelation> DocRelations { get; set; } = new List<DocRelation>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Table("DocDataTagIdx")]
[Index("Tag", Name = "IDX_DocDataTagIdx_Tag")]
public partial class DocDataTagIdx
{
    [Key]
    public int Id { get; set; }

    public int DocId { get; set; }

    [StringLength(100)]
    public string? Tag { get; set; }

    [ForeignKey("DocId")]
    [InverseProperty("DocDataTagIdxes")]
    public virtual DocDatum Doc { get; set; } = null!;
}

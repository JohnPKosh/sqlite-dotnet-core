using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SqliteConsole.Infrastructure.Models;

[Table("DocRelation")]
[Index("RelatedType", "DocId", Name = "IDX_DocRelation_Covering")]
[Index("DocId", Name = "IDX_DocRelation_DocId")]
public partial class DocRelation
{
    [Key]
    public int Id { get; set; }

    public int DocId { get; set; }

    [StringLength(50)]
    public string RelatedId { get; set; } = null!;

    [StringLength(50)]
    public string RelatedType { get; set; } = null!;

    [ForeignKey("DocId")]
    [InverseProperty("DocRelations")]
    public virtual DocDatum Doc { get; set; } = null!;
}

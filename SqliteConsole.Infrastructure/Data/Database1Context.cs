using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqliteConsole.Infrastructure.Models;

namespace SqliteConsole.Infrastructure.Data;

public static class Database1Consts
{
    internal const string DEFAULT_CONNECTIONSTRING = "Data Source=Database1.db;";
}

public partial class Database1Context : DbContext
{
    public Database1Context()
    {
    }

    public Database1Context(DbContextOptions<Database1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DocDataEgressLog> DocDataEgressLogs { get; set; }

    public virtual DbSet<DocDataTagIdx> DocDataTagIdxes { get; set; }

    public virtual DbSet<DocDatum> DocData { get; set; }

    public virtual DbSet<DocItem> DocItems { get; set; }

    public virtual DbSet<DocItemEgressLog> DocItemEgressLogs { get; set; }

    public virtual DbSet<DocRelation> DocRelations { get; set; }

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(Database1Consts.DEFAULT_CONNECTIONSTRING);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocDataEgressLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocDataEgressLog_Id");

            entity.HasOne(d => d.Doc).WithMany(p => p.DocDataEgressLogs).HasConstraintName("FK_DocData_DocDataEgressLog");
        });

        modelBuilder.Entity<DocDataTagIdx>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocDataTagIdx_Id");

            entity.HasOne(d => d.Doc).WithMany(p => p.DocDataTagIdxes).HasConstraintName("FK_DocData_DocDataTagIdx");
        });

        modelBuilder.Entity<DocDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocData_Id");

            entity.Property(e => e.CreateUtc).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<DocItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocItem_Id");

            entity.Property(e => e.CreateUtc).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Doc).WithMany(p => p.DocItems).HasConstraintName("FK_DocData_DocItem");
        });

        modelBuilder.Entity<DocItemEgressLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocItemEgressLog_Id");

            entity.HasOne(d => d.DocItem).WithMany(p => p.DocItemEgressLogs).HasConstraintName("FK_DocItem_DocItemEgressLog");
        });

        modelBuilder.Entity<DocRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DocRelationIdx_Id");

            entity.HasOne(d => d.Doc).WithMany(p => p.DocRelations).HasConstraintName("FK_DocData_DocRelation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


public static class Database1ContextFactory
{
    public static Database1Context Create() => Create(Database1Consts.DEFAULT_CONNECTIONSTRING);

    public static Database1Context Create(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Database1Context>();
        optionsBuilder.UseSqlite(connectionString);

        var context = new Database1Context(optionsBuilder.Options);
        context.Database.EnsureCreated();

        return context;
    }
}
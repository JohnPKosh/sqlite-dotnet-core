using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqliteConsole.Infrastructure.Models;

namespace SqliteConsole.Infrastructure.Data;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Command> Commands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\junk\\sqlite-data\\test.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("account");

            entity.Property(e => e.FirstName).HasColumnType("VARCHAR(30)");
            entity.Property(e => e.LastName).HasColumnType("VARCHAR(30)");
            entity.Property(e => e.MiddleName).HasColumnType("VARCHAR(30)");
        });

        modelBuilder.Entity<Command>(entity =>
        {
            entity.ToTable("command");

            entity.Property(e => e.CommandArgs)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(500)");
            entity.Property(e => e.CommandPath)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(255)");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''")
                .HasColumnType("VARCHAR(50)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XenovaGamings_Repo.Models;

public partial class XenovaDbContext : DbContext
{
    public XenovaDbContext()
    {
    }

    public XenovaDbContext(DbContextOptions<XenovaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Databaseping> Databasepings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=dpg-d3dnc9r7mgec73d13u30-a.singapore-postgres.render.com;Port=5432;Database=xenova_db;Username=xenova_db_user;Password=MZ7iTbLegOcknyfT9fW57AN9cLf8wKFH;SslMode=Require;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Databaseping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("databaseping");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

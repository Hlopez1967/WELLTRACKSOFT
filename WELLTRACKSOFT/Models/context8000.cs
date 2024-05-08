using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WELLTRACKSOFT.Models;

public partial class context8000 : DbContext
{
    public context8000()
    {
    }

    public context8000(DbContextOptions<context8000> options)
        : base(options)
    {
    }

    public virtual DbSet<TabPayersCatalog> TabPayersCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=P3NWPLSK12SQL-v03.shr.prod.phx3.secureserver.net;Database=WellTrackDb;TrustServerCertificate=true;persist security info=True;user id=welladmin;password=0hrS114@w");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("welladmin");

        modelBuilder.Entity<TabPayersCatalog>(entity =>
        {
            entity.ToTable("tabPayersCatalog", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PayerId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PayerID");
            entity.Property(e => e.PayerName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PayerType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("I - Institutional; P - Private");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

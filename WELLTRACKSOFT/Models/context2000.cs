using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WELLTRACKSOFT.Models;

public partial class context2000 : DbContext
{
    public context2000()
    {
    }

    public context2000(DbContextOptions<context2000> options)
        : base(options)
    {
    }

    public virtual DbSet<TabBillingCodesModifier> TabBillingCodesModifiers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=P3NWPLSK12SQL-v03.shr.prod.phx3.secureserver.net;Database=WellTrackDb;TrustServerCertificate=true;persist security info=True;user id=welladmin;password=0hrS114@w");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("welladmin");

        modelBuilder.Entity<TabBillingCodesModifier>(entity =>
        {
            entity.ToTable("tabBillingCodesModifiers", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BcmodifierCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BCModifierCode");
            entity.Property(e => e.BcmodifierDesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BCModifierDesc");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

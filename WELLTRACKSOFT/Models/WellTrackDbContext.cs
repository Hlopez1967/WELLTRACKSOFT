using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WELLTRACKSOFT.Models;

public partial class WellTrackDbContext : DbContext
{
    public WellTrackDbContext()
    {
    }

    public WellTrackDbContext(DbContextOptions<WellTrackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabCompanyGeneralInfo> TabCompanyGeneralInfos { get; set; }
    public virtual DbSet<TabStreetAddress> TabStreetAddresses { get; set; }
    public virtual DbSet<TabPlacesOfService> TabPlacesOfServices { get; set; }
    public virtual DbSet<TabCompanyStreetAddress> TabCompanyStreetAddresses { get; set; }
    public virtual DbSet<TabStandardBillingCode> TabStandardBillingCodes { get; set; }
    public virtual DbSet<TabBillingCodeType> TabBillingCodeTypes { get; set; }
    public virtual DbSet<TabBillingCodesModifier> TabBillingCodesModifiers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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

        modelBuilder.Entity<TabBillingCodeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabbillingcodetype_bctypecode_primary");

            entity.ToTable("tabBillingCodeType", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BctypeCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("CPT; HCPCS")
                .HasColumnName("BCTypeCode");
            entity.Property(e => e.BctypeDesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BCTypeDesc");
        });

        modelBuilder.Entity<TabStandardBillingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabstandardbillingcodes_stdbillingcodeid_primary");

            entity.ToTable("tabStandardBillingCodes", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StdBillingCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StdBillingCodeDesc)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabCompanyStreetAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabCompanyStreetAddress_id_primary");

            entity.ToTable("tabCompanyStreetAddress", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDefault).HasDefaultValue(true);
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TabCompanyGeneralInfoId).HasColumnName("tabCompanyGeneralInfoId");
            entity.Property(e => e.TabPlacesOfServiceId).HasColumnName("tabPlacesOfServiceId");
            entity.Property(e => e.TabStreetAddressId).HasColumnName("tabStreetAddressId");
        });

        modelBuilder.Entity<TabPlacesOfService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabplacesofservice_placeofservid_primary");

            entity.ToTable("tabPlacesOfService", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlaceOfServiceCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.PlaceOfServiceDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabCompanyGeneralInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabcompanygeneralinfo_id_primary");

            entity.ToTable("tabCompanyGeneralInfo", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AboutMe)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Domain)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Ein)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Employer Identification Number")
                .HasColumnName("EIN");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LegalName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Mpi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Medicaid/Medicare Provider ID")
                .HasColumnName("MPI");
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("National Provider ID")
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxonomyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TradeName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabStreetAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tabstreetaddress_id_primary");

            entity.ToTable("tabStreetAddress", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

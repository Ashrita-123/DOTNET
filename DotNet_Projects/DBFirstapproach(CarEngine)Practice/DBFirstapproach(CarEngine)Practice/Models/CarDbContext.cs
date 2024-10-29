using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstapproach_CarEngine_Practice.Models;

public partial class CarDbContext : DbContext
{
    public CarDbContext()
    {
    }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarTbl> CarTbls { get; set; }

    public virtual DbSet<EngineTbl> EngineTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5JT3T8O\\ASHRITA;Database=CarDB;User Id=sa;Password=user123;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarTbl>(entity =>
        {
            entity.HasKey(e => e.CarId);

            entity.ToTable("CarTbl");

            entity.Property(e => e.CarId).ValueGeneratedNever();
            entity.Property(e => e.CarName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Engine).WithMany(p => p.CarTbls)
                .HasForeignKey(d => d.EngineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarTbl_EngineTbl");
        });

        modelBuilder.Entity<EngineTbl>(entity =>
        {
            entity.HasKey(e => e.EngineId);

            entity.ToTable("EngineTbl");

            entity.Property(e => e.EngineId).ValueGeneratedNever();
            entity.Property(e => e.EngineType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

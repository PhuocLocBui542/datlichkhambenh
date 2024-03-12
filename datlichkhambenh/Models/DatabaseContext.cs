using System;
using System.Collections.Generic;
using datlichkhambenh.Models;
using Microsoft.EntityFrameworkCore;

namespace datlichkhambenh.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bacsi> Bacsis { get; set; }

    public virtual DbSet<Benhnhan> Benhnhans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lichkham> Lichkhams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bacsi>(entity =>
        {
            entity.HasKey(e => e.Mabs);

            entity.ToTable("bacsi");

            entity.Property(e => e.Mabs).HasColumnName("mabs");
            entity.Property(e => e.Makhoa).HasColumnName("makhoa");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Tenbs)
                .HasMaxLength(250)
                .HasColumnName("tenbs");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Bacsis)
                .HasForeignKey(d => d.Makhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bacsi_khoa");
        });

        modelBuilder.Entity<Benhnhan>(entity =>
        {
            entity.HasKey(e => e.Mabn);

            entity.ToTable("benhnhan");

            entity.Property(e => e.Mabn).HasColumnName("mabn");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .HasColumnName("account");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(50)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Tenbn)
                .HasMaxLength(250)
                .HasColumnName("tenbn");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa);

            entity.ToTable("khoa");

            entity.Property(e => e.Makhoa).HasColumnName("makhoa");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(250)
                .HasColumnName("tenkhoa");
        });

        modelBuilder.Entity<Lichkham>(entity =>
        {
            entity.ToTable("lichkham");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mabn).HasColumnName("mabn");
            entity.Property(e => e.Mabs).HasColumnName("mabs");
            entity.Property(e => e.Ngaykham)
                .HasColumnType("date")
                .HasColumnName("ngaykham");
            entity.Property(e => e.Noidung)
                .HasColumnType("text")
                .HasColumnName("noidung");

            entity.HasOne(d => d.MabnNavigation).WithMany(p => p.Lichkhams)
                .HasForeignKey(d => d.Mabn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lichkham_benhnhan");

            entity.HasOne(d => d.MabsNavigation).WithMany(p => p.Lichkhams)
                .HasForeignKey(d => d.Mabs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lichkham_bacsi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

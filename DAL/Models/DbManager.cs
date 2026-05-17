using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class DbManager : DbContext
{
    public DbManager()
    {
    }

    public DbManager(DbContextOptions<DbManager> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Inspiration> Inspirations { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<WeeklySchedule> WeeklySchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='D:\\Chavy_Blizinsky\\projectAdrichalut\\projact_2\\projact_2\\dataBase.mdf';Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D80AB272CF");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PaidAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RemainingAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RemainingMeetings).HasDefaultValue(0);
            entity.Property(e => e.SelectedProfile).HasMaxLength(100);
            entity.Property(e => e.TotalMeetings).HasDefaultValue(0);
        });

        modelBuilder.Entity<Inspiration>(entity =>
        {
            entity.HasKey(e => e.InspirationId).HasName("PK__tmp_ms_x__9FEF7B9070BCB1B8");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Style).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId).HasName("PK__Meetings__E9F9E94C74B859A2");

            entity.Property(e => e.Date).HasMaxLength(20);
            entity.Property(e => e.FromHour).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ToHour).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Meetings_Customers");
        });

        modelBuilder.Entity<WeeklySchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeeklySc__3214EC07EF60893C");

            entity.Property(e => e.FromHour).HasMaxLength(20);
            entity.Property(e => e.ToHour).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

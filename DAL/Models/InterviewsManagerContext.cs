using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class InterviewsManagerContext : DbContext
{
    public InterviewsManagerContext()
    {
    }

    public InterviewsManagerContext(DbContextOptions<InterviewsManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AROQ7OV;Initial Catalog=InterviewsManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName).HasMaxLength(40);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName).HasMaxLength(40);
            entity.Property(e => e.PhoneNumber).HasMaxLength(40);
            entity.Property(e => e.RoleInCompany).HasMaxLength(40);
            entity.Property(e => e.Street).HasMaxLength(40);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.InterviewDate).HasColumnType("date");
            entity.Property(e => e.InterviewNumber).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleInCompany).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

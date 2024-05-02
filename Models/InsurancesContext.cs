using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace insurance.Models;

public partial class InsurancesContext : DbContext
{
  

    public InsurancesContext(DbContextOptions<InsurancesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__1299A8610146172B");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__ED1FC9EA265B408B");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.CardHolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("card_holder");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("card_number");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.ExpDate)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("exp_date");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Policies__47DA3F03C0728CBD");

            entity.Property(e => e.PolicyId).HasColumnName("policy_id");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Insurer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("insurer");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using expensetracker.Data;
using Microsoft.EntityFrameworkCore;

namespace expensetracker.Models;

public partial class ExpensetrackerContext : expensetrackerIdentityContext
{

    public ExpensetrackerContext(DbContextOptions<ExpensetrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<IncomeCategory> IncomeCategories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-U65U0C5;Database=expensetracker;Encrypt=False;MultipleActiveResultSets=true;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("budgets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("expenses");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.Asset).HasColumnName("asset");
            entity.Property(e => e.DateOfSepnding)
                .HasColumnType("datetime")
                .HasColumnName("date_of_sepnding");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExpenseCategory).HasColumnName("expense_category");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Recurring).HasColumnName("recurring");

            entity.HasOne(d => d.ExpenseCategoryNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.ExpenseCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_expenses_expense_categories");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.ToTable("expense_categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Decsription).HasColumnName("decsription");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.ToTable("incomes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.DateOfReceiving)
                .HasColumnType("datetime")
                .HasColumnName("date_of_receiving");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IncomeCategory).HasColumnName("income_category");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Recurring).HasColumnName("recurring");

            entity.HasOne(d => d.IncomeCategoryNavigation).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.IncomeCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_incomes_income_categories");
        });

        modelBuilder.Entity<IncomeCategory>(entity =>
        {
            entity.ToTable("income_categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Decsription).HasColumnName("decsription");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

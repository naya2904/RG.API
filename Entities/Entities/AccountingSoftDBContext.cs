﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class AccountingSoftDBContext : DbContext
    {
        public AccountingSoftDBContext()
        {
        }

        public AccountingSoftDBContext(DbContextOptions<AccountingSoftDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccountCatalog> TblAccountCatalogs { get; set; } = null!;
        public virtual DbSet<TblAccountingSeat> TblAccountingSeats { get; set; } = null!;
        public virtual DbSet<TblAllocation> TblAllocations { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblDepartment> TblDepartments { get; set; } = null!;
        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblIdType> TblIdTypes { get; set; } = null!;
        public virtual DbSet<TblLog> TblLogs { get; set; } = null!;
        public virtual DbSet<TblReport> TblReports { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblSeatApproval> TblSeatApprovals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.;Database=AccountingSoftDB;Integrated Security=True;User ID=SA;Password=Aljimo**04;Trusted_Connection=False;");
                optionsBuilder.UseSqlServer("Server=.;Database=AccountingSoftDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccountCatalog>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__tblAccou__05B22F6066C8692B");

                entity.ToTable("tblAccountCatalog");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_NAME");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.Conversion).HasColumnName("CONVERSION");
            });

            modelBuilder.Entity<TblAccountingSeat>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__tblAccou__79B8992383F9F3F7");

                entity.ToTable("tblAccountingSeats");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.SeatValue)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SEAT_VALUE");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblAccountingSeats)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAccoun__ACCOU__45F365D3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblAccountingSeats)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAccoun__CUSTO__46E78A0C");
            });

            modelBuilder.Entity<TblAllocation>(entity =>
            {
                entity.HasKey(e => e.AllocationId)
                    .HasName("PK__tblAlloc__712E755AA2D94596");

                entity.ToTable("tblAllocations");

                entity.Property(e => e.AllocationId).HasColumnName("ALLOCATION_ID");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblAllocations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAlloca__CUSTO__5441852A");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblAllocations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblAlloca__EMPLO__534D60F1");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tblCusto__1CE12D37602B227C");

                entity.ToTable("tblCustomers");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_ADDRESS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.IdType).HasColumnName("ID_TYPE");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCustom__ID_TY__412EB0B6");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tblDepar__63E613629DEAF38F");

                entity.ToTable("tblDepartments");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DepartmentDescription)
                    .HasMaxLength(50)
                    .HasColumnName("DEPARTMENT_DESCRIPTION");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tblEmplo__CBA14F48F70F7117");

                entity.ToTable("tblEmployees");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Genre).HasColumnName("GENRE");

                entity.Property(e => e.Identification).HasColumnName("IDENTIFICATION");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .HasColumnName("USER_PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblEmploy__DEPAR__3E52440B");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblEmploy__ROLE___3D5E1FD2");
            });

            modelBuilder.Entity<TblIdType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__tblIdTyp__274CEC82783784C9");

                entity.ToTable("tblIdTypes");

                entity.Property(e => e.IdType)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_TYPE");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE_DESCRIPTION");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__tblLogs__4364C8827D125C7B");

                entity.ToTable("tblLogs");

                entity.Property(e => e.LogId).HasColumnName("LOG_ID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TIME");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.LogDescription)
                    .HasMaxLength(500)
                    .HasColumnName("LOG_DESCRIPTION");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblLogs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblLogs__EMPLOYE__49C3F6B7");
            });

            modelBuilder.Entity<TblReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__tblRepor__B106F6BBBAE0CBF5");

                entity.ToTable("tblReports");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Credits)
                    .HasMaxLength(50)
                    .HasColumnName("CREDITS");

                entity.Property(e => e.Debts)
                    .HasMaxLength(50)
                    .HasColumnName("DEBTS");

                entity.Property(e => e.FinalBalance)
                    .HasMaxLength(50)
                    .HasColumnName("FINAL_BALANCE");

                entity.Property(e => e.InitialBalance)
                    .HasMaxLength(50)
                    .HasColumnName("INITIAL_BALANCE");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReport__ACCOU__5070F446");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReport__SEAT___4F7CD00D");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRoles__5AC4D222B47C11D3");

                entity.ToTable("tblRoles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(50)
                    .HasColumnName("ROLE_DESCRIPTION");
            });

            modelBuilder.Entity<TblSeatApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId)
                    .HasName("PK__tblSeatA__6B47F41C9DEAE5BE");

                entity.ToTable("tblSeatApprovals");

                entity.Property(e => e.ApprovalId).HasColumnName("APPROVAL_ID");

                entity.Property(e => e.ApprovalStatus).HasColumnName("APPROVAL_STATUS");

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.TblSeatApprovals)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblSeatAp__SEAT___4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
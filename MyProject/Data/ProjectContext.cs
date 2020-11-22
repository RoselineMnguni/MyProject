using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyProject.Models;

namespace MyProject.Data
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DimensionRose> DimensionRose { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Initial Catalog=Project;Data Source=LAPTOP-PERHG9NA\\SQLEXPRESS;Trusted_Connection=true");
            }
#pragma warning restore
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<DimensionRose>(entity =>
            {
                entity.HasKey(e=>e.EmployeeNumber);

                entity.Property(e => e.Attrition)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessTravel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DistanceFromHome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EducationField)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeCount)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnvironmentSatisfaction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobInvolvement)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobLevel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobRole)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobSatisfaction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumCompaniesWorked)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Over18)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OverTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RelationshipSatisfaction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockOptionLevel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalWorkingYears)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrainingTimesLastYear)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkLifeBalance)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearsAtCompany)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearsInCurrentRole)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearsSinceLastPromotion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearsWithCurrManager)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

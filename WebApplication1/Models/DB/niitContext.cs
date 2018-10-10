using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.models.DB
{
    public partial class niitContext : DbContext
    {
        public niitContext()
        {
        }

        public niitContext(DbContextOptions<niitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deptt> Deptt { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=niit;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deptt>(entity =>
            {
                entity.HasKey(e => e.Deptid);

                entity.ToTable("deptt");

                entity.Property(e => e.Deptid)
                    .HasColumnName("deptid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Strength).HasColumnName("strength");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("emp");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("edfk");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuildingADLRepositoryLib.Models;

public partial class TechnicalSupportContext : DbContext
{
    public TechnicalSupportContext()
    {
    }

    public TechnicalSupportContext(DbContextOptions<TechnicalSupportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<IssueCustomer> IssueCustomers { get; set; }

    public virtual DbSet<IssueCustomerReopen> IssueCustomerReopens { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=technicalSupport;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerID).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CustomerName).HasMaxLength(250);
            entity.Property(e => e.Notes).HasMaxLength(350);
            entity.Property(e => e.Responsabilty).HasMaxLength(350);
            entity.Property(e => e.Tel).HasMaxLength(250);
        });

        modelBuilder.Entity<IssueCustomer>(entity =>
        {
            entity.HasKey(e => e.IssueID);

            entity.ToTable("IssueCustomer");

            entity.Property(e => e.IssueID).HasColumnName("IssueID");
            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .HasColumnName("answer");
            entity.Property(e => e.AnswerDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Attachment).HasMaxLength(250);
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.DateClose).HasColumnType("smalldatetime");
            entity.Property(e => e.IS_close).HasColumnName("IS_close");
            entity.Property(e => e.IS_ReOpen).HasColumnName("IS_ReOpen");
            entity.Property(e => e.IssueSubject).HasMaxLength(50);
            entity.Property(e => e.IssueType).HasComment("1-  ويب ابليكشن\r\n2- موبايل ابليكشن\r\n3- موقع اليكترونى\r\n4- ايميلات");
            entity.Property(e => e.Priority)
                .HasComment("1-طوارىء\r\n2- عاجل\r\n3-عادى")
                .HasColumnName("priority");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<IssueCustomerReopen>(entity =>
        {
            entity.HasKey(e => e.ReIssueID);

            entity.ToTable("IssueCustomerReopen");

            entity.Property(e => e.ReIssueID)
                .ValueGeneratedNever()
                .HasColumnName("ReIssueID");
            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .HasColumnName("answer");
            entity.Property(e => e.AnswerDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Details).HasMaxLength(350);
            entity.Property(e => e.IssueID).HasColumnName("IssueID");
            entity.Property(e => e.UserID).HasColumnName("UserID");

            entity.HasOne(d => d.Issue).WithMany(p => p.IssueCustomerReopens)
                .HasForeignKey(d => d.IssueID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IssueCustomerReopen_IssueCustomer");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserID);

            entity.ToTable("tbUsers");

            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.CustomerID  ).HasColumnName("CustomerID");
            entity.Property(e => e.Is_active).HasColumnName("Is_active");
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.UserName).HasMaxLength(150);

            entity.HasOne(d => d.Customer).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbUsers_Customer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

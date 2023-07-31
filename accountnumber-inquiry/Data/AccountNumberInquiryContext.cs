using accountnumber_inquiry.Models.Entity;
using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace accountnumber_inquiry.Data
{
   public class AccountNumberInquiryContext : DbContext
   {
      // create constructor
      public AccountNumberInquiryContext(DbContextOptions<AccountNumberInquiryContext> options) : base(options)
      {

      }

      // protected override
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ABCS_M_DDMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_DDMEMO>().HasNoKey();
         modelBuilder.Entity<ABCS_M_CDMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_CDMEMO>().HasNoKey();
         modelBuilder.Entity<ABCS_M_GLMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_GLMEMO>().HasNoKey();
         modelBuilder.Entity<ABCS_M_LNMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_LNMEMO>().HasNoKey();
      }

      // list a table
      public virtual DbSet<ABCS_M_DDMAST>? ABCS_M_DDMAST { get; set; }
      public virtual DbSet<ABCS_M_DDMEMO>? ABCS_M_DDMEMO { get; set; }
      public virtual DbSet<ABCS_M_CDMAST>? ABCS_M_CDMAST { get; set; }
      public virtual DbSet<ABCS_M_CDMEMO>? ABCS_M_CDMEMO { get; set; }
      public virtual DbSet<ABCS_M_GLMAST>? ABCS_M_GLMAST { get; set; }
      public virtual DbSet<ABCS_M_GLMEMO>? ABCS_M_GLMEMO { get; set; }
      public virtual DbSet<ABCS_M_LNMAST>? ABCS_M_LNMAST { get; set; }
      public virtual DbSet<ABCS_M_LNMEMO>? ABCS_M_LNMEMO { get; set; }
   }
}

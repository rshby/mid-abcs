using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inquiry.Data
{
   public class InquiryContext : DbContext
   {
      // create constructor
      public InquiryContext(DbContextOptions<InquiryContext> options) : base(options)
      {

      }

      // override
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ABCS_M_CFMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_DDMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_DDMEMO>().HasNoKey();
         modelBuilder.Entity<ABCS_M_CDMAST>().HasNoKey();
         modelBuilder.Entity<ABCS_M_CDMEMO>().HasNoKey();
      }

      // list a table
      public virtual DbSet<ABCS_M_CFMAST> ABCS_M_CFMAST { get; set; }
      public virtual DbSet<ABCS_M_DDMAST> ABCS_M_DDMAST { get; set; }
      public virtual DbSet<ABCS_M_DDMEMO> ABCS_M_DDMEMO { get; set; }
      public virtual DbSet<ABCS_M_CDMAST> ABCS_M_CDMAST { get; set; }
      public virtual DbSet<ABCS_M_CDMEMO> ABCS_M_CDMEMO { get; set; }
   }
}

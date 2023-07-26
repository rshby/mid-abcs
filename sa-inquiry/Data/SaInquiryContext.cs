using Microsoft.EntityFrameworkCore;
using sa_inquiry.Models.Entity;

namespace sa_inquiry.Data
{
   public class SaInquiryContext : DbContext
   {
      // create constructor
      public SaInquiryContext(DbContextOptions<SaInquiryContext> options) : base(options)
      {

      }

      // ovveride
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ABCS_M_DDMAST>().HasNoKey();
      }

      // list a table
      public virtual DbSet<ABCS_M_DDMAST>? ABCS_M_DDMAST { get; set; }
   }
}

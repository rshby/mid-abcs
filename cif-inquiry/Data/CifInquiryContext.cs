using Inquiry.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace cif_inquiry.Data
{
   public class CifInquiryContext : DbContext
   {
      // create constructor
      public CifInquiryContext(DbContextOptions<CifInquiryContext> options) : base(options)
      {

      }

      // ovveride
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ABCS_M_CFMAST>().HasNoKey();
      }

      // list a table
      public virtual DbSet<ABCS_M_CFMAST>? ABCS_M_CFMAST { get; set; }
   }
}

using inq_cif.Models;
using Microsoft.EntityFrameworkCore;

namespace inq_cif.Data
{
   public class InqCifContext : DbContext
   {
      // create constructor
      public InqCifContext(DbContextOptions<InqCifContext> options) : base(options)
      {

      }

      // override
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ABCS_M_CFMAST>().HasNoKey();
      }

      // list table
      public virtual DbSet<ABCS_M_CFMAST>? ABCS_M_CFMAST { get; set; }
   }
}

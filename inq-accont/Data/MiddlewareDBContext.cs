using inq_accont.Models.Entity.MiddlewareEntity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Data
{
    public class MiddlewareDBContext : DbContext
    {
        // create constructor
        public MiddlewareDBContext(DbContextOptions<MiddlewareDBContext> options) : base(options)
        {

        }

        // override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BRINJOURNALSEQ>().HasNoKey();
        }

        // list a table
        public virtual DbSet<BRINJOURNALSEQ>? BRINJOURNALSEQ { get; set; }
    }
}

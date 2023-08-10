using inq_accont.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace inq_accont.Data
{
    public class InqAccountContext : DbContext
    {
        // create constructor
        public InqAccountContext(DbContextOptions<InqAccountContext> options) : base(options)
        {

        }

        // override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ABCS_M_DDMEMO>();
            modelBuilder.Entity<ABCS_M_DDMAST>();
            modelBuilder.Entity<ABCS_M_CDMEMO>().HasNoKey();
            modelBuilder.Entity<ABCS_M_CDMAST>().HasNoKey();
            modelBuilder.Entity<ABCS_M_GLMEMO>().HasNoKey();
            modelBuilder.Entity<ABCS_M_GLMAST>().HasNoKey();
            modelBuilder.Entity<ABCS_M_LNMEMO>().HasNoKey();
            modelBuilder.Entity<ABCS_M_LNMAST>().HasNoKey();
            modelBuilder.Entity<ABCS_P_DDPAR2>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        // list a table
        public virtual DbSet<ABCS_M_DDMAST>? ABCS_M_DDMAST { get; set; }
        public virtual DbSet<ABCS_M_DDMEMO>? ABCS_M_DDMEMO { get; set; }
        public virtual DbSet<ABCS_M_CDMEMO>? ABCS_M_CDMEMO { get; set; }
        public virtual DbSet<ABCS_M_CDMAST>? ABCS_M_CDMAST { get; set; }
        public virtual DbSet<ABCS_M_GLMEMO>? ABCS_M_GLMEMO { get; set; }
        public virtual DbSet<ABCS_M_GLMAST>? ABCS_M_GLMAST { get; set; }
        public virtual DbSet<ABCS_M_LNMEMO>? ABCS_M_LNMEMO { get; set; }
        public virtual DbSet<ABCS_M_LNMAST>? ABCS_M_LNMAST { get; set; }
        public virtual DbSet<ABCS_P_DDPAR2>? ABCS_P_DDPAR2 { get; set; }
    }
}

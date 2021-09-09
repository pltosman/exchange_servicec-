using System;
using CI.interview.pltosman.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CI.interview.pltosman.DataAccess.Concrete.EntityFramework.Contexts
{
    public class InterviewContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CI_interview");     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<FixerRate>(x => x.HasKey(ua => new { ua.Id }));
            modelBuilder.Entity<Rate>().HasOne(u => u.FixerRate).WithMany(a => a.Rates).HasForeignKey(u => u.FixerRateId);
            modelBuilder.Entity<ExcelData>(x => x.HasKey(ua => new { ua.Id }));

        }


        public DbSet<Rate> Rates { get; set; }
        public DbSet<FixerRate> FixerRates { get; set; }

        public DbSet<ExcelData> ExcelData { get; set; }
    }
}

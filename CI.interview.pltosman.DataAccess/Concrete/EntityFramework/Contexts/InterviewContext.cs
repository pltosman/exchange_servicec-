using System;
using CI.interview.pltosman.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CI.interview.pltosman.DataAccess.Concrete.EntityFramework.Contexts
{
    public class InterviewContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName:"CI_interview");     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Rate>(x => x.HasKey(ua => new { ua.Base,ua.Date,ua.Symbol }));
        
            modelBuilder.Entity<ExcelData>(x => x.HasKey(ua => new { ua.Id }));
            modelBuilder.Entity<Merge>(x => x.HasKey(ua => new { ua.Id }));

        }


        public DbSet<Rate> Rates { get; set; }  
        public DbSet<ExcelData> ExcelData { get; set; }
        public DbSet<Merge> Merges { get; set; }
    }
}

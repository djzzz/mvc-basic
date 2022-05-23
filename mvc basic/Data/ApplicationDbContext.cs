using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mvc_basic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<People> people { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<People>().HasData(
                new People() { Id = 1, Name = "Charls", Number = 123, City = "London" },
                new People() { Id = 2, Name = "Carl", Number = 123, City = "Sweden" },
                new People() { Id = 3, Name = "Luzy", Number = 123, City = "USA" },
                new People() { Id = 4, Name = "Mario", Number = 123, City = "Italy" }
            );
        }
        #endregion
        

    }
}

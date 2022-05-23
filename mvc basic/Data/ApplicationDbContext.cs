using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
using mvc_basic.Models.Cities;
using mvc_basic.Models.Countrys;

namespace mvc_basic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<People> people { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countrys { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //countrys
            Country England = new Country() { CountryId = 1, Name = "England"};
            Country Russia = new Country() { CountryId = 2, Name = "Russia" };
            Country Spain = new Country() { CountryId = 3, Name = "Spain" };
            Country Sweden = new Country() { CountryId = 4, Name = "Sweden" };

            //cities
            City London = new City() { CityId = 1, Name = "London" , CountryId = England.CountryId };
            City Birmingham = new City() { CityId = 2, Name = "Birmingham", CountryId = England.CountryId };
            City Glasgow = new City() { CityId = 3, Name = "Glasgow", CountryId = England.CountryId };
            City Liverpool = new City() { CityId = 4, Name = "Liverpool", CountryId = England.CountryId };

            City Moscow = new City() { CityId = 5, Name = "Moscow", CountryId = Russia.CountryId };
            City Saint_Petersburg = new City() { CityId = 6, Name = "Saint Petersburg", CountryId = Russia.CountryId };
            City Novosibirsk = new City() { CityId = 7, Name = "Novosibirsk", CountryId = Russia.CountryId };
            City Yekaterinburg = new City() { CityId = 8, Name = "Yekaterinburg", CountryId = Russia.CountryId };

            City Madrid = new City() { CityId = 9, Name = "Madrid", CountryId = Spain.CountryId };
            City Barcelona = new City() { CityId = 10, Name = "Barcelona", CountryId = Spain.CountryId };
            City Valencia = new City() { CityId = 11, Name = "Valencia", CountryId = Spain.CountryId };
            City Seville = new City() { CityId = 12, Name = "Seville", CountryId = Spain.CountryId };

            City Stockholm = new City() { CityId = 13, Name = "Stockholm", CountryId = Sweden.CountryId };
            City Gothenburg = new City() { CityId = 14, Name = "Gothenburg", CountryId = Sweden.CountryId };
            City Malmo = new City() { CityId = 15, Name = "Malmö", CountryId = Sweden.CountryId };
            City Uppsala = new City() { CityId = 16, Name = "Uppsala", CountryId = Sweden.CountryId };

            People Simon = new People() { Id = 1, Name = "Simon", Number = 123, CityId = London.CityId };
            People Frans = new People() { Id = 2, Name = "Frans", Number = 123, CityId = Liverpool.CityId };
            People Roger = new People() { Id = 3, Name = "Roger", Number = 123, CityId = Moscow.CityId };
            People Alf = new People() { Id = 4, Name = "Alf", Number = 123, CityId = Madrid.CityId };
            People Bruno = new People() { Id = 5, Name = "Bruno", Number = 123, CityId = Seville.CityId };
            People Shan = new People() { Id = 6, Name = "Shan", Number = 123, CityId = Stockholm.CityId };
            People Elf = new People() { Id = 7, Name = "Elf", Number = 123, CityId = Gothenburg.CityId };

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>()
                .HasOne(e => e.Country)
                .WithMany(e => e.Cities);
                
            modelBuilder.Entity<People>()
                .HasOne(e => e.City)
                .WithMany(e => e.Peoples);
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithOne(e => e.Country);
            modelBuilder.Entity<Country>().HasData(
                England,
                Russia,
                Sweden,
                Spain
            );

            modelBuilder.Entity<City>().HasData(
                London,
                Birmingham,
                Glasgow,
                Liverpool,
                Moscow,
                Saint_Petersburg,
                Novosibirsk,
                Yekaterinburg,
                Madrid,
                Barcelona,
                Valencia,
                Seville,
                Stockholm,
                Gothenburg,
                Malmo,
                Uppsala
            );
            modelBuilder.Entity<People>().HasData(
                Simon,
                Frans,
                Roger,
                Alf,
                Bruno,
                Shan,
                Elf
            );
        }
        #endregion
        

    }
}

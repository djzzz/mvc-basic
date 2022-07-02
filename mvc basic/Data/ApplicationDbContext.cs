using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_basic.Models;
using mvc_basic.Models.Cities;
using mvc_basic.Models.Countrys;
using mvc_basic.Models.ManyToMany;
using mvc_basic.Models.Languages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using mvc_basic.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace mvc_basic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<People> people { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countrys { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguagePeople> LanguagePeople { get; set; }
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

            People Simon = new People() { PeopleId = 1, Name = "Simon", Number = 123, CityId = London.CityId };
            People Frans = new People() { PeopleId = 2, Name = "Frans", Number = 123, CityId = Liverpool.CityId };
            People Roger = new People() { PeopleId = 3, Name = "Roger", Number = 123, CityId = Moscow.CityId };
            People Alf = new People() { PeopleId = 4, Name = "Alf", Number = 123, CityId = Madrid.CityId };
            People Bruno = new People() { PeopleId = 5, Name = "Bruno", Number = 123, CityId = Seville.CityId };
            People Shan = new People() { PeopleId = 6, Name = "Shan", Number = 123, CityId = Stockholm.CityId };
            People Elf = new People() { PeopleId = 7, Name = "Elf", Number = 123, CityId = Gothenburg.CityId };

            Language Spanish = new Language() { LanguageID = 1, Name = "Spanish" };
            Language France = new Language() { LanguageID = 2, Name = "France" };
            LanguagePeople SpanishToSimon = new LanguagePeople() { LanguageId = Spanish.LanguageID, PeopleId = Simon.PeopleId };

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LanguagePeople>()
                .HasKey(e => new { e.LanguageId, e.PeopleId });
            modelBuilder.Entity<LanguagePeople>()
                .HasOne(e => e.Language)
                .WithMany(e => e.LanguagePeople);
            modelBuilder.Entity<LanguagePeople>()
                .HasOne(e => e.People)
                .WithMany(e => e.LanguagePeople);
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
            modelBuilder.Entity<Language>().HasData(
                Spanish,
                France
            );
            modelBuilder.Entity<LanguagePeople>().HasData(
                SpanishToSimon
            );
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            DateTime birth = new DateTime(1800, 5, 1, 8, 30, 52);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                FirstName = "Admin",
                LastName = "Adminson",
                Birth = birth,
                PasswordHash = hasher.HashPassword(null, "password")
            });
            modelBuilder.Entity<IdentityUserRole<String>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
        #endregion
        

    }
}

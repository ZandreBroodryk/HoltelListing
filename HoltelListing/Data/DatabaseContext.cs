using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoltelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Islands",
                    ShortName = "CI"
                }
                );

            builder.Entity<Hotel>().HasData(
               new Hotel
               {
                   ID = 1,
                   Name = "Sandals Resort and Spa",
                   Address = "Negril",
                   CountryId = 1,
                   Rating = 4
               },
               new Hotel
               {
                   ID = 2,
                   Name = "Grand Palladium",
                   Address = "Nassua",
                   CountryId = 2,
                   Rating = 3
               },
               new Hotel
               {
                   ID = 3,
                   Name = "Comfort Suites",
                   Address = "Georgetown",
                   CountryId = 3,
                   Rating = 4
               }
               );
        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
    }
}

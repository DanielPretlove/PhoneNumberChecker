using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Data.Access
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Name = "Australia", CountryCode = "AU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Name = "New Zealand", CountryCode = "NZ" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = Guid.NewGuid(), Name = "Italy", CountryCode = "IT" });
        }

        public DbSet<Country> Countries { get; set; }
    }
}

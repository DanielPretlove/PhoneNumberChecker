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
            base.OnModelCreating(modelBuilder);
            var dataEntity = Assembly
                .GetAssembly(typeof(DataEntity))
                .GetTypes()
                .Where(a => a.BaseType == typeof(DataEntity));

            foreach(var entityType in dataEntity)
            {
                modelBuilder.Entity(entityType);
            }
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace InterpolatedStrings
{
    internal class EFContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Person.db");
    }
}

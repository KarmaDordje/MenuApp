using Microsoft.EntityFrameworkCore;

using Recipe.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the QuantityType enum property
            modelBuilder.Entity<Ingredient>()
            .OwnsOne(i => i.Measurement, measurement =>
            {
                // Configure the Quanity column
                measurement.Property(m => m.Quantity)
                    .HasColumnName("Quanity");

                // Configure the QuantityType enum column
                measurement.Property(m => m.Name)
                    .HasColumnName("QuantityType")
                    .HasConversion(
                        v => (int)v,   // Convert enum to integer for database
                        v => (QuantityType)v); // Convert integer to enum for .NET
            });

            // Add other entity configurations here if needed
        }

    }
}

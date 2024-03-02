using Microsoft.EntityFrameworkCore;
using Recipe.Infrastructure.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public void Find(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

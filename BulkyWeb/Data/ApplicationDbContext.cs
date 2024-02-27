using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData // this is how you can manually add data to database from code side and after run command in package manager console first add-migration SeedCategoryTable and after update-database, by this you're able to insert data from entity framework to sql database table.
                (
                    new Category { Id = 1,Name = "Action",DisplayOrder = 1 },
                    new Category { Id = 2,Name = "SciFi",DisplayOrder = 2 },
                    new Category { Id = 3,Name = "History",DisplayOrder = 3 }
                );
        }
    }
}

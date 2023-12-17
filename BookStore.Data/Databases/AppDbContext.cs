
using BookStore.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Databases
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes()) 
            {
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties()) 
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }
            }
        }
    }
}

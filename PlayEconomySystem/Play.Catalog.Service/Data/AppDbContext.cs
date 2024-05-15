using Microsoft.EntityFrameworkCore;
using Play.Catalog.Service.Models;
using Play.Catalog.Service.Models.DTOs.Items;

namespace Play.Catalog.Service.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ItemDto> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemDto>().HasData(new ItemDto
            {
               Id = Guid.NewGuid(),
               Description = "New Item",
               Name = "Some name",
               CreatedDate = DateTimeOffset.Now,
               Price = 1.2M


            });

            modelBuilder.Entity<ItemDto>().HasData(new ItemDto
            {
                Id = Guid.NewGuid(),
                Description = "New Item2",
                Name = "Some name2",
                CreatedDate = DateTimeOffset.Now,
                Price = 1.5M


            });
        }
    }
}

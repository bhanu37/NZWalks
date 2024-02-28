using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficultys { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Image> Images { get; set; }

        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("5b974dfc-f341-4f96-b806-5a33d9fab18e"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("e941cda3-902d-4088-a349-3f04390454ec"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("67fcfa6a-9c3d-425b-a529-74c017fedbd1"),
                    Name = "Hard"
                }
            };
            
            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("68fd2b61-45a7-4c92-b81a-9dfb85a1d3e5"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "SomeAucklandImage.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("e9c4f3a8-7bcf-473d-b0d8-2c9d3feef98d"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "SomeNorthlandImage.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("36a7d891-22e5-4f3b-8a56-61b92a58d7c2"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "SomeBopImage.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("d4320f6b-9f2c-4ee4-a9db-815e02b7c5e1"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "SomeWellingtonImage.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("a5e37c91-7f9d-45b1-b7cc-c0a3f2a6bd8e"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "SomeNelsonImage.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("8f462aa2-6152-48a5-b6ef-3d90b8f76b8f"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "SomeSouthlandImage.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Data
{


    public class NZWalkDBContext : DbContext   
    {

        public NZWalkDBContext(DbContextOptions<NZWalkDBContext> dbcontextoption): base(dbcontextoption)
        {
                
        }

        public DbSet<Difficulty> Deficulties { get; set; }

        public  DbSet<Regions> Regionspoperties { get; set; }
        public  DbSet<Walks> WalksProperties { get; set; }

        public  DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Difficulty
            var difficulies = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("e89da2b2-3be3-4761-8d90-00371b8ca5b8"),
                    Name = "Hard"
                }
            };

            //seed difficulty data to database
            modelBuilder.Entity<Difficulty>().HasData(difficulies);

            //seed data for Regions
            var regions = new List<Regions>()
            {
                new Regions()
                {
                    Id = Guid.Parse("0d914a9a-eb9a-43ce-8193-30c55d1ac8ac"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Auckland_skyline_from_Mt_Eden.jpg/2560px-Auckland_skyline_from_Mt_Eden.jpg"
                },
                new Regions()
                {
                    Id = Guid.Parse("614ffc6f-81f6-4d1d-bc99-58aff329f3b1"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Wellington_City.jpg/2560px-Wellington_City.jpg"
                },
                new Regions()
                {
                    Id = Guid.Parse("e89da2b2-3be3-4761-8d90-00371b8ca5b8"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Christchurch_Cathedral_Square.jpg/2560px-Christchurch_Cathedral_Square.jpg"
                }
            };

            //seed Regions data to database
            modelBuilder.Entity<Regions>().HasData(regions);
        }
    }
}

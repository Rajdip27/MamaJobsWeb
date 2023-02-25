using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.DbDependencies
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 1,
                CountryName = "Bangladesh",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<District>().HasData(new District
            {
                Id = 1,
                DistrictName = "Barisal",
                CountryId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            }) ;
            modelBuilder.Entity<Thana>().HasData(new Thana
            {
                Id = 1,
                ThanaName = "Porijpuer",
                DistrictId = 1,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
           
            modelBuilder.Entity<Relative>().HasData(new Relative
            {
                Id = 1,
                RelativeName = "Techer",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Reading>().HasData(new Reading
            {
                Id = 1,
                ReadingName = "Bangla",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Writing>().HasData(new Writing
            {
                Id = 1,
                WritingName = "Bangla",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
            modelBuilder.Entity<Speaking>().HasData(new Speaking
            {
                Id = 1,
                SpeakingName = "Bangla",
                CreatedBy = 1,
                CreatedDateUtc = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            });
        }

    }
}

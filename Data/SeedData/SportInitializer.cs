using DynastyOfChampions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DynastyOfChampions.Api.Data.SeedData
{
    public class SportInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public SportInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport() { Id = 1, Name = "Football" }
            );
        }
    }
}

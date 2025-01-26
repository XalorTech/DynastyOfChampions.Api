using DynastyOfChampions.Api.Data.Enums;
using DynastyOfChampions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DynastyOfChampions.Api.Data.SeedData
{
    public class NationalCollegeAthleticAssociationFootballInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public NationalCollegeAthleticAssociationFootballInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<League>().HasData(
                new League() {
                    Id = (int)LeagueEnums.NCAAF,
                    SportId = (int)SportEnums.FOOTBALL,
                    LeagueDetails = [
                        new LeagueDetail()
                        {
                            Id = 1,
                            Name = "Intercollegiate Athletic Association of the United States",
                            Abbreviation = "IAAUS",
                            BeginDate = new DateOnly(1906, 03, 31),
                            EndDate = new DateOnly(1910, 01, 01), // Exact date unknown
                            LeagueId = (int)LeagueEnums.NCAAF
                        },
                        new LeagueDetail()
                        {
                            Id = 2,
                            Name = "National College Athletic Association Football League",
                            Abbreviation = "NCAAF",
                            BeginDate = new DateOnly(1910, 01, 01), // Exact date unknown
                            LeagueId = (int)LeagueEnums.NCAAF
                        }
                    ]
                }
            );
        }
    }
}

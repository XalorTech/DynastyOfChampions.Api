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
                    Id = 1,
                    Name = "National College Athletic Association Football League",
                    Abbreviation = "NCAAF",
                    SportId = 1,
                    Divisions =
                    [
                        new Division()
                        {
                            Id = 1,
                            DivisionDetails =
                            [
                                new DivisionDetail()
                                {
                                    Id = 1,
                                    Name = "NCAA Division I Football",
                                    Abbreviation = "I",
                                    BeginDate = new DateOnly(1973, 8, 1),
                                    EndDate = new DateOnly(1978, 8, 1),
                                    DivisionId = 1
                                },
                                new DivisionDetail()
                                {
                                    Id = 4,
                                    Name = "NCAA Division I-A Football",
                                    Abbreviation = "I-A",
                                    BeginDate = new DateOnly(1978, 8, 1),
                                    EndDate = new DateOnly(2006, 8, 1),
                                    DivisionId = 1
                                },
                                new DivisionDetail()
                                {
                                    Id = 6,
                                    Name = "NCAA Division I Football Bowl Subdivision",
                                    Abbreviation = "FBS",
                                    BeginDate = new DateOnly(2006, 8, 1),
                                    DivisionId = 1
                                }
                            ]
                        },
                        new Division()
                        {
                            Id = 2,
                            DivisionDetails =
                            [
                                new DivisionDetail()
                                {
                                    Id = 2,
                                    Name = "NCAA Division II Football",
                                    Abbreviation = "II",
                                    BeginDate = new DateOnly(1973, 8, 1),
                                    DivisionId = 2
                                }
                            ]
                        },
                        new Division()
                        {
                            Id = 3,
                            DivisionDetails =
                            [
                                new DivisionDetail()
                                {
                                    Id = 3,
                                    Name = "NCAA Division III Football",
                                    Abbreviation = "III",
                                    BeginDate = new DateOnly(1973, 8, 1),
                                    DivisionId = 3
                                }
                            ]
                        },
                        new Division()
                        {
                            Id = 4,
                            DivisionDetails =
                            [
                                new DivisionDetail()
                                {
                                    Id = 5,
                                    Name = "NCAA Division I-AA Football",
                                    Abbreviation = "I-AA",
                                    BeginDate = new DateOnly(1978, 8, 1),
                                    EndDate = new DateOnly(2006, 8, 1),
                                    DivisionId = 4
                                },
                                new DivisionDetail()
                                {
                                    Id = 7,
                                    Name = "NCAA Division I Football Championship Subdivision",
                                    Abbreviation = "FCS",
                                    BeginDate = new DateOnly(2006, 8, 1),
                                    DivisionId = 4
                                }
                            ]
                        }
                    ]
                }
            );
        }
    }
}

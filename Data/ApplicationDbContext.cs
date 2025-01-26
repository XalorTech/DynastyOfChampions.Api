using DynastyOfChampions.Api.Data.SeedData;
using DynastyOfChampions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DynastyOfChampions.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region DbSets

        public DbSet<Sport> Sports { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Sport

            modelBuilder.Entity<Sport>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(sport => sport.Id);

                // Properties
                entity.Property(sport => sport.Name)
                    .HasMaxLength(32)
                    .IsRequired();

                // Many-to-One Relationships
                entity.HasMany(sport => sport.Leagues)
                    .WithOne(league => league.Sport)
                    .HasForeignKey(league => league.SportId);
            });

            #endregion

            #region League & League Detail

            modelBuilder.Entity<League>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(league => league.Id);

                // One-to-Many Relationships
                entity.HasOne(league => league.Sport)
                    .WithMany(sport => sport.Leagues)
                    .HasForeignKey(league => league.SportId);

                // Many-to-One Relationships
                entity.HasMany(league => league.LeagueDetails)
                    .WithOne(leagueDetail => leagueDetail.League)
                    .HasForeignKey(leagueDetail => leagueDetail.LeagueId);
                entity.HasMany(league => league.Seasons)
                    .WithOne(season => season.League)
                    .HasForeignKey(season => season.LeagueId);
            });

            modelBuilder.Entity <LeagueDetail>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(leagueDetail => leagueDetail.Id);

                // Properties
                entity.Property(leagueDetail => leagueDetail.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(leagueDetail => leagueDetail.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired();

                // One-to-Many Relationships
                entity.HasOne(leagueDetail => leagueDetail.League)
                    .WithMany(league => league.LeagueDetails)
                    .HasForeignKey(leagueDetail => leagueDetail.LeagueId);
            });

            #endregion

            #region Season

            modelBuilder.Entity<Season>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(season => new
                {
                    season.Year,
                    season.LeagueId
                });

                // One-to-Many Relationships
                entity.HasOne(season => season.League)
                    .WithMany(league => league.Seasons)
                    .HasForeignKey(season => season.LeagueId);

                // Many-to-Many Relationships
                entity.HasMany(season => season.Conferences)
                    .WithMany(conference => conference.Seasons)
                    .UsingEntity<SeasonConference>();
                entity.HasMany(season => season.Divisions)
                    .WithMany(division => division.Seasons)
                    .UsingEntity<SeasonDivision>();
            });

            #endregion

            #region Conference & ConferenceDetail

            modelBuilder.Entity<Conference>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(conference => conference.Id);

                // Many-to-One Relationships
                entity.HasMany(conference => conference.ConferenceDetails)
                    .WithOne(conferenceDetail => conferenceDetail.Conference)
                    .HasForeignKey(conferenceDetail => conferenceDetail.ConferenceId);

                // Many-to-Many Relationships
                entity.HasMany(conference => conference.Seasons)
                    .WithMany(season => season.Conferences)
                    .UsingEntity<SeasonConference>();
                entity.HasMany(conference => conference.Divisions)
                    .WithMany(division => division.Conferences)
                    .UsingEntity<ConferenceDivision>();
            });

            modelBuilder.Entity<ConferenceDetail>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(conferenceDetail => conferenceDetail.Id);

                // Properties
                entity.Property(conferenceDetail => conferenceDetail.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(conferenceDetail => conferenceDetail.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired();

                // One-to-Many Relationships
                entity.HasOne(conferenceDetail => conferenceDetail.Conference)
                    .WithMany(conference => conference.ConferenceDetails)
                    .HasForeignKey(conferenceDetail => conferenceDetail.ConferenceId);
            });

            #endregion

            #region Division & DivisionDetail

            modelBuilder.Entity<Division>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(division => division.Id);

                // Many-to-One Relationships
                entity.HasMany(division => division.DivisionDetails)
                    .WithOne(divisionDetail => divisionDetail.Division)
                    .HasForeignKey(divisionDetail => divisionDetail.DivisionId);

                // Many-to-Many Relationships
                entity.HasMany(division => division.Seasons)
                    .WithMany(season => season.Divisions)
                    .UsingEntity<SeasonDivision>();
            });

            modelBuilder.Entity<DivisionDetail>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(divisionDetail => divisionDetail.Id);

                // Properties
                entity.Property(divisionDetail => divisionDetail.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(divisionDetail => divisionDetail.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired();

                // One-to-Many Relationships
                entity.HasOne(divisionDetail => divisionDetail.Division)
                    .WithMany(division => division.DivisionDetails)
                    .HasForeignKey(divisionDetail => divisionDetail.DivisionId);
            });

            #endregion

            #region SeasonConference, SeasonDivision, & ConferenceDivision

            modelBuilder.Entity<SeasonConference>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(seasonConference => new
                {
                    seasonConference.SeasonId,
                    seasonConference.ConferenceId
                });
            });

            modelBuilder.Entity<SeasonDivision>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(seasonDivision => new
                {
                    seasonDivision.SeasonId,
                    seasonDivision.DivisionId
                });
            });

            modelBuilder.Entity<ConferenceDivision>(entity =>
            {
                // Primary Key(s)
                entity.HasKey(conferenceDivision => new
                {
                    conferenceDivision.SeasonId,
                    conferenceDivision.ConferenceId,
                    conferenceDivision.DivisionId
                });
            });

            #endregion

            base.OnModelCreating(modelBuilder);

            #region Initialize Seed Data

            new SportInitializer(modelBuilder).Seed();
            new NationalCollegeAthleticAssociationFootballInitializer(modelBuilder).Seed();

            #endregion
        }
    }
}
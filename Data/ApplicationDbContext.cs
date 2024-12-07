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
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<ConferenceDetail> ConferenceDetails { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<DivisionDetail> DivisionDetails { get; set; }
        public DbSet<ConferenceDivisionRelationship> ConferenceDivisionRelationships { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Sport

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(sport => sport.Id);

                entity.Property(sport => sport.Name)
                    .HasMaxLength(32)
                    .IsRequired();

                entity.HasMany(sport => sport.Leagues)
                    .WithOne(league => league.Sport)
                    .HasForeignKey(league => league.SportId);
            });

            #endregion

            #region League

            modelBuilder.Entity<League>(entity =>
            {
                entity.HasKey(league => league.Id);

                entity.Property(league => league.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(league => league.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired(); 

                entity.HasOne(league => league.Sport)
                    .WithMany(sport => sport.Leagues)
                    .HasForeignKey(league => league.SportId);
                entity.HasMany(league => league.Conferences)
                    .WithOne(conference => conference.League)
                    .HasForeignKey(conference => conference.LeagueId);
                entity.HasMany(league => league.Divisions)
                    .WithOne(division => division.League)
                    .HasForeignKey(division => division.LeagueId);
            });

            #endregion

            #region Conference & ConferenceDetail

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.HasKey(conference => conference.Id);

                entity.HasMany(conference => conference.ConferenceDetails)
                    .WithOne(conferenceDetail => conferenceDetail.Conference)
                    .HasForeignKey(conferenceDetail => conferenceDetail.ConferenceId);
                entity.HasMany(conference => conference.ConferenceDivisionRelationships)
                    .WithOne(conferenceDivisionRelationship => conferenceDivisionRelationship.Conference)
                    .HasForeignKey(conferenceDivisionRelationship => conferenceDivisionRelationship.ConferenceId);
            });

            modelBuilder.Entity<ConferenceDetail>(entity =>
            {
                entity.HasKey(conferenceDetail => conferenceDetail.Id);

                entity.Property(conferenceDetail => conferenceDetail.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(conferenceDetail => conferenceDetail.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired();

                entity.HasOne(conferenceDetail => conferenceDetail.Conference)
                    .WithMany(conference => conference.ConferenceDetails)
                    .HasForeignKey(conferenceDetail => conferenceDetail.ConferenceId);
            });

            #endregion

            #region Division & DivisionDetail

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(division => division.Id);

                entity.HasMany(division => division.DivisionDetails)
                    .WithOne(divisionDetail => divisionDetail.Division)
                    .HasForeignKey(divisionDetail => divisionDetail.DivisionId);
                entity.HasMany(division => division.ConferenceDivisionRelationships)
                    .WithOne(conferenceDivisionRelationship => conferenceDivisionRelationship.Division)
                    .HasForeignKey(conferenceDivisionRelationship => conferenceDivisionRelationship.DivisionId);
            });

            modelBuilder.Entity<DivisionDetail>(entity =>
            {
                entity.HasKey(divisionDetail => divisionDetail.Id);

                entity.Property(divisionDetail => divisionDetail.Name)
                    .HasMaxLength(32)
                    .IsRequired();
                entity.Property(divisionDetail => divisionDetail.Abbreviation)
                    .HasMaxLength(8)
                    .IsRequired();

                entity.HasOne(divisionDetail => divisionDetail.Division)
                    .WithMany(division => division.DivisionDetails)
                    .HasForeignKey(divisionDetail => divisionDetail.DivisionId);
            });

            #endregion

            #region ConferenceDivisionRelationship

            modelBuilder.Entity<ConferenceDivisionRelationship>(entity =>
            {
                entity.HasKey(conferenceDivisionRelationship => new
                {
                    conferenceDivisionRelationship.ConferenceId,
                    conferenceDivisionRelationship.DivisionId
                });

                entity.HasOne(conferenceDivisionRelationship => conferenceDivisionRelationship.Conference)
                    .WithMany(conference => conference.ConferenceDivisionRelationships)
                    .HasForeignKey(conferenceDivisionRelationship => conferenceDivisionRelationship.ConferenceId);
                entity.HasOne(conferenceDivisionRelationship => conferenceDivisionRelationship.Division)
                    .WithMany(division => division.ConferenceDivisionRelationships)
                    .HasForeignKey(conferenceDivisionRelationship => conferenceDivisionRelationship.DivisionId);
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
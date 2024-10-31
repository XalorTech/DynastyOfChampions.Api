using DynastyOfChampions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DynastyOfChampions.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region DbSets

        public DbSet<Sport> Sports { get; set; }
        public DbSet<League> Leagues { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Sport

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(sport => sport.Id);

                entity.Property(sport => sport.Name)
                    .HasMaxLength(24)
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
                    .HasMaxLength(64)
                    .IsRequired();
                entity.Property(league => league.Abbreviation)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasOne(league => league.Sport)
                    .WithMany(sport => sport.Leagues)
                    .HasForeignKey(league => league.SportId);
            });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
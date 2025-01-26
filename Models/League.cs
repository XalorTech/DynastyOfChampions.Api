namespace DynastyOfChampions.Api.Models
{
    public class League
    {
        public required int Id { get; set; }
        
        #region Foreign Keys

        public required int SportId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public Sport? Sport { get; set; }
        public ICollection<LeagueDetail>? LeagueDetails { get; set; }
        public ICollection<Season>? Seasons { get; set; }

        #endregion
    }
}
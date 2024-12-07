namespace DynastyOfChampions.Api.Models
{
    public class Division
    {
        public required int Id { get; set; }

        #region Foreign Keys

        public int? LeagueId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public League? League { get; set; }
        public ICollection<DivisionDetail>? DivisionDetails { get; set; }
        public ConferenceDivisionRelationship? ConferenceDivisionRelationship { get; set; }
        public ICollection<ConferenceDivisionRelationship>? ConferenceDivisionRelationships { get; set; }

        #endregion
    }
}

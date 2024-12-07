namespace DynastyOfChampions.Api.Models
{
    public class Conference
    {
        public required int Id { get; set; }

        #region Foreign Keys

        public int? LeagueId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public League? League { get; set; }
        public ICollection<ConferenceDetail>? ConferenceDetails { get; set; }
        public ConferenceDivisionRelationship? ConferenceDivisionRelationship { get; set; }
        public ICollection<ConferenceDivisionRelationship>? ConferenceDivisionRelationships { get; set; }

        #endregion
    }
}

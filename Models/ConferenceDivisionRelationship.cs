namespace DynastyOfChampions.Api.Models
{
    public class ConferenceDivisionRelationship
    {
        public required int ConferenceId { get; set; }
        public required int DivisionId { get; set; }

        #region Relational Objects & Collections

        public Conference? Conference { get; set; }
        public ICollection<Conference>? Conferences { get; set; }
        public Division? Division { get; set; }
        public ICollection<Division>? Divisions { get; set; }

        #endregion
    }
}

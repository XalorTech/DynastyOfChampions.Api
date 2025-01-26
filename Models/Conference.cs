namespace DynastyOfChampions.Api.Models
{
    public class Conference
    {
        public required int Id { get; set; }

        #region Relational Objects & Collections

        public ICollection<ConferenceDetail>? ConferenceDetails { get; set; }
        public ICollection<Season>? Seasons { get; set; }
        public ICollection<Division>? Divisions { get; set; }

        #endregion
    }
}

namespace DynastyOfChampions.Api.Models
{
    public class Season
    {
        public required DateOnly Year { get; set; }
        public required int LeagueId { get; set; }

        #region Relational Objects & Collections

        public League? League { get; set; }
        public ICollection<Conference>? Conferences { get; set; }
        public ICollection<Division>? Divisions { get; set; }

        #endregion
    }
}

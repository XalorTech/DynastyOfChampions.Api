namespace DynastyOfChampions.Api.Models
{
    public class Division
    {
        public required int Id { get; set; }

        #region Relational Objects & Collections

        public ICollection<DivisionDetail>? DivisionDetails { get; set; }
        public ICollection<Season>? Seasons { get; set; }
        public ICollection<Conference>? Conferences { get; set; }

        #endregion
    }
}

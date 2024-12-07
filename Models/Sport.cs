namespace DynastyOfChampions.Api.Models
{
    public class Sport
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        #region Relational Objects & Collections

        public ICollection<League>? Leagues { get; set; }

        #endregion
    }
}
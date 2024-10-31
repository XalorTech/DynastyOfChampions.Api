namespace DynastyOfChampions.Api.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Relational Objects & Collections

        public ICollection<League> Leagues { get; set; }

        #endregion
    }
}
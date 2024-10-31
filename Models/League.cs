namespace DynastyOfChampions.Api.Models
{
    public class League
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        
        #region Foreign Keys

        public int SportId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public required Sport Sport { get; set; }

        #endregion
    }
}
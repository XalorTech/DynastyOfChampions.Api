namespace DynastyOfChampions.Api.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        
        #region Foreign Keys

        public int SportId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public Sport Sport { get; set; }

        #endregion
    }
}
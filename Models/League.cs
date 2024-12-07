namespace DynastyOfChampions.Api.Models
{
    public class League
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        
        #region Foreign Keys

        public required int SportId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public Sport? Sport { get; set; }
        public ICollection<Conference>? Conferences { get; set; }
        public ICollection<Division>? Divisions { get; set; }

        #endregion
    }
}
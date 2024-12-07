namespace DynastyOfChampions.Api.Models
{
    public class DivisionDetail
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public required DateOnly BeginDate { get; set; }
        public DateOnly? EndDate { get; set; }

        #region Foreign Keys

        public required int DivisionId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public Division? Division { get; set; }

        #endregion
    }
}

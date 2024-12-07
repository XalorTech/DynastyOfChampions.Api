namespace DynastyOfChampions.Api.Models
{
    public class ConferenceDetail
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public required DateOnly BeginDate { get; set; }
        public DateOnly? EndDate { get; set; }

        #region Foreign Keys

        public required int ConferenceId { get; set; }

        #endregion

        #region Relational Objects & Collections

        public Conference? Conference { get; set; }

        #endregion
    }
}

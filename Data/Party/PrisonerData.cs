
namespace MTPrison.Data.Party {
    public sealed class PrisonerData : UniqueData {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Offense { get; set; } = string.Empty;
        public DateTime DoB { get; set; }
        public DateTime DateOfRelease { get; set; }
        public DateTime DateOfImprisonment { get; set; }

        //public string PrisonCell { get; set; }
    }
}


namespace MTPrison.Data.Party {
    public sealed class PrisonerData : UniqueData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Offense { get; set; }
        public DateTime? DoB { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public DateTime? DateOfImprisonment { get; set; }

        //public string PrisonCell { get; set; }
    }
}


namespace MTPrison.Data.Party {
    public sealed class PrisonerData : UniqueData {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Offense { get; set; } = string.Empty;
        public DateTime DateOfImprisonment { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}

using System.ComponentModel;

namespace MTPrison.Data.Party {
    public sealed class CellData : UniqueData {
        public int CellNumber { get; set; }
        public int Capacity { get; set; }
        public CellType? Type { get; set; }
        public string? Section { get; set; }
        public string? CountryId { get; set; }
        public DateTime? Inspection { get; set; }
    }

    public enum CellType {
        [Description("Deluxe")] Deluxe = 0,
        [Description("Duo")] Duo = 1,
        [Description("Solitary")] Solitary = 2,
        [Description("Not applicable")] NotApplicable = 9
    }
}

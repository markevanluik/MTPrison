using System.ComponentModel;

namespace MTPrison.Data.Party {
    public sealed class CellData : UniqueData {
        public int CellNumber { get; set; }
        public string Section { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public CellType Type { get; set; }
    }
    public enum CellType {
        [Description("Solitary")] Solitary = 0,
        [Description("Duo")] Duo = 1,
        [Description("Quad")] Quad = 2,
        [Description("Deluxe")] Deluxe = 3,
        [Description("Standard")] Standard = 9
    }
}

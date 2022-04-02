using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class CellsInitializer : BaseInitializer<CellData> {
        public CellsInitializer(PrisonDb? db) : base(db, db?.Cells) { }
        internal static CellData createCell(string id, int cellNumber, int capacity, string type, string section) => new() {
            Id = id,
            CellNumber = cellNumber,
            Capacity = capacity,
            Type = type,
            Section = section
        };

        protected override IEnumerable<CellData> getEntities => new[] {
            createCell("52345", 1, 3, "Deluxe", "C"),
            createCell("62345", 21, 2, "Duo", "B"),
            createCell("72345", 31, 1, "Solitary", "A"),
            createCell("82345", 32, 1, "Solitary", "A"),
        };
    }
}

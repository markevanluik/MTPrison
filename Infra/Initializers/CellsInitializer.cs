using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class CellsInitializer : BaseInitializer<CellData> {
        public CellsInitializer(PrisonDb? db) : base(db, db?.Cells) { }
        internal static CellData createCell(string id, string section, int cellNumber, int capacity, CellType type) => new() {
            Id = id,
            Section = section,
            CellNumber = cellNumber,
            Capacity = capacity,
            Type = type
        };

        protected override IEnumerable<CellData> getEntities => new[] {
            createCell("52345", "C", 1, 3, CellType.Deluxe),
            createCell("62345", "B", 21, 2, CellType.Duo),
            createCell("72345", "A", 31, 1, CellType.Solitary),
            createCell("82345", "A", 32, 1, CellType.Solitary)
        };
    }
}

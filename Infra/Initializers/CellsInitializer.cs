using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class CellsInitializer : BaseInitializer<CellData> {
        public CellsInitializer(PrisonDb? db) : base(db, db?.Cells) { }
        internal static CellData createCell(string id, int cellNumber, int capacity, CellType type, string section, string country, DateTime date) => new() {
            Id = id,
            CellNumber = cellNumber,
            Capacity = capacity,
            Type = type,
            Section = section,
            CountryId = country,
            Inspection = date,

        };

        protected override IEnumerable<CellData> getEntities => new[] {
            createCell("52345", 1, 3, CellType.Deluxe, "C", "USA", new DateTime(2022, 09, 10)),
            createCell("62345", 21, 2, CellType.Duo, "B", "GBR", new DateTime(2023, 08, 07)),
            createCell("72345", 31, 1, CellType.Solitary, "A", "FRA", new DateTime(2024, 12, 24)),
            createCell("82345", 32, 1, CellType.Solitary, "A", "ESP", new DateTime(2025, 01, 01))
        };
    }
}

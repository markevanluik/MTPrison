using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class CellsInitializer : BaseInitializer<CellData> {
        public CellsInitializer(PrisonDb? db) : base(db, db?.Cells) { }
        internal static CellData createCell(string id, int cellNumber, int capacity, string type, string section, string country, DateTime date, IsoGender gender) => new() {
            Id = id,
            CellNumber = cellNumber,
            Capacity = capacity,
            Type = type,
            Section = section,
            Country = country,
            Inspection = date,
            Gender = gender

        };

        protected override IEnumerable<CellData> getEntities => new[] {
            createCell("52345", 1, 3, "Deluxe", "C", "USA", new DateTime(2022, 09, 10), IsoGender.Female),
            createCell("62345", 21, 2, "Duo", "B", "GBR", new DateTime(2023, 08, 07), IsoGender.Male),
            createCell("72345", 31, 1, "Solitary", "A", "FRA", new DateTime(2024, 12, 24), IsoGender.Male),
            createCell("82345", 32, 1, "Solitary", "A", "ESP", new DateTime(2025, 01, 01), IsoGender.NotKnown)
        };
    }
}

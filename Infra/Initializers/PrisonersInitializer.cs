using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class PrisonersInitializer : BaseInitializer<PrisonerData> {
        public PrisonersInitializer(PrisonDb? db) : base(db, db?.Prisoners) { }
        internal static PrisonerData createPrisoner(string firstN, string lastN, string SSN, string cntry, string offense, DateTime imprisndD, DateTime releaseD) => new() {
            Id = firstN + lastN,
            FirstName = firstN,
            LastName = lastN,
            SSN = SSN,
            Country = cntry,
            Offense = offense,
            DateOfImprisonment = imprisndD,
            DateOfRelease = releaseD
        };

        protected override IEnumerable<PrisonerData> getEntities => new[] {
            createPrisoner("Bobby", "Smith", "39890222012", "YEM", "Something serious", new DateTime(1990, 2, 25), new DateTime(2025, 1, 30)),
            createPrisoner("John", "Doe", "93-435-953", "NZL", "Burglary", new DateTime(2022, 1, 1), new DateTime(2023, 7, 5)),
            createPrisoner("Jane", "Doe", "98765-43210", "GBR", "Manslaughter", new DateTime(2018, 8, 14), new DateTime(2025, 4, 10)),
            createPrisoner("Foo", "Bar", "49804150123", "LKA", "GTA", new DateTime(1997, 11, 28), new DateTime(2023, 4, 01)),
            createPrisoner("Claude", "Speed", "3234150123", "USA", "GTA2", new DateTime(1999, 10, 22), new DateTime(2024, 1, 10)),
            createPrisoner("Lexus", "Texus", "1234150712", "USA", "GTA3", new DateTime(2001, 10, 22), new DateTime(2026, 1, 10))
        };
    }
}

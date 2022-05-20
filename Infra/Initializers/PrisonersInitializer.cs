using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class PrisonersInitializer : BaseInitializer<PrisonerData> {
        public PrisonersInitializer(PrisonDb? db) : base(db, db?.Prisoners) { }
        internal static PrisonerData createPrisoner(string firstname, string lastname, DateTime DoB, string offense, DateTime imprisonedDate, DateTime releaseDate) => new() {
            Id = firstname + lastname,
            FirstName = firstname,
            LastName = lastname,
            DoB = DoB,
            Offense = offense,
            DateOfImprisonment = imprisonedDate,
            DateOfRelease = releaseDate
        };

        protected override IEnumerable<PrisonerData> getEntities => new[] {
            createPrisoner("Bobby", "Smith", new DateTime(1989, 2, 12), "Insurance Fraud", new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("John", "Doe", new DateTime(1989, 2, 12), "Burglary", new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("Jane", "Doe", new DateTime(1989, 2, 12), "Manslaughter", new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("Foo", "Bar", new DateTime(1989, 2, 12), "GTA", new DateTime(1999, 1, 1), new DateTime(2002, 2, 2))
        };
    }
}

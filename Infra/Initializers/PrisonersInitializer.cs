using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class PrisonersInitializer : BaseInitializer<PrisonerData> {
        public PrisonersInitializer(PrisonDb? db) : base(db, db?.Prisoners) { }
        internal static PrisonerData createPrisoner(string firstname, string lastname, string offense, DateTime DoB, DateTime imprisonedDate, DateTime releaseDate) {
            var prisoner = new PrisonerData {
                Id = firstname + lastname,
                FirstName = firstname,
                LastName = lastname,
                Offense = offense,
                DoB = DoB,
                DateOfImprisonment = imprisonedDate,
                DateOfRelease = releaseDate
            };
            return prisoner;
        }

        protected override IEnumerable<PrisonerData> getEntities => new[] {
            createPrisoner("Bobby", "Smith", "Insurance Fraud", new DateTime(1989, 2, 12), new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("John", "Doe", "Burglary", new DateTime(1989, 2, 12), new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("Jane", "Doe", "Manslaughter", new DateTime(1989, 2, 12), new DateTime(1999, 1, 1), new DateTime(2002, 2, 2)),
            createPrisoner("Foo", "Bar", "GTA", new DateTime(1989, 2, 12), new DateTime(1999, 1, 1), new DateTime(2002, 2, 2))
        };
    }
}

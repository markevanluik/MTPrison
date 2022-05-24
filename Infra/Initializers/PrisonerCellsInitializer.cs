using MTPrison.Data.Party;

namespace MTPrison.Infra.Initializers {
    public sealed class PrisonerCellsInitializer : BaseInitializer<PrisonerCellData> {
        public PrisonerCellsInitializer(PrisonDb? db) : base(db, db?.PrisonerCells) { }

        internal static PrisonerCellData createBaggage(string prId, string ceId, string code, string imprisndD, string releaseD) => new() {
            Id = prId + ceId,
            PrisonerId = prId,
            CellId = ceId,
            Code = code,
            Name = imprisndD,
            NativeName = releaseD
        };
        //many-to-many relation, id's need to match
        protected override IEnumerable<PrisonerCellData> getEntities => new[] {
            createBaggage("BobbySmith", "52345", "Teach", "25.02.1990", "30.01.2025"),
            createBaggage("JohnDoe", "62345", "Research", "01.01.2022", "05.07.2023"),
            createBaggage("JaneDoe", "72345", "Learn", "14.08.2018", "10.04.2025"),
            createBaggage("FooBar", "82345", "Learn", "25.10.2011", "01.04.2023")
        };
    }
}

using MTPrison.Data.Party;


namespace MTPrison.Infra.Initializers {
    public sealed class PrisonerCellsInitializer : BaseInitializer<PrisonerCellData> {
        public PrisonerCellsInitializer(PrisonDb? db) : base(db, db?.PrisonerCells) { }

        internal static PrisonerCellData createBaggage(string prId, string ceId, string code, string name, string nativeName) => new() {
            Id = prId + ceId,
            PrisonerId = prId,
            CellId = ceId,
            Code = code,
            Name = name,
            NativeName = nativeName
        };
        //many-to-many relation, id's need to match
        protected override IEnumerable<PrisonerCellData> getEntities => new[] {
            createBaggage("BobbySmith", "52345", "Teach", "Alien", "Space Alien"),
            createBaggage("JohnDoe", "62345", "Research", "Zolda", "Space Zolda"),
            createBaggage("JaneDoe", "72345", "Learn", "Buda", "Space Buda"),
            createBaggage("FooBar", "82345", "Learn", "Buda", "Space Buda")
        };
    }
}

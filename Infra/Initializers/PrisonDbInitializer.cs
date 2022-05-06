namespace MTPrison.Infra.Initializers {
    public static class PrisonDbInitializer {
        public static void Init(PrisonDb? db) {
            new PrisonersInitializer(db).Init();
            new CellsInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new PrisonerCellsInitializer(db).Init();
            new CountryCurrenciesInitializer(db).Init();
        }
    }
}

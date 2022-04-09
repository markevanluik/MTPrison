using Microsoft.EntityFrameworkCore;
using MTPrison.Data;

namespace MTPrison.Infra.Initializers {
    public abstract class BaseInitializer<TData> where TData : UniqueData{
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        public void Init() {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }

        protected abstract IEnumerable<TData> getEntities { get; }

        internal static bool isCorrectIsoCode(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
    }

    public static class PrisonDbInitializer {
        public static void Init(PrisonDb? db) {
            new PrisonersInitializer(db).Init();
            new CellsInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();

        }
    }
}

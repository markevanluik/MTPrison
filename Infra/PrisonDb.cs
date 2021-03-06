using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;

namespace MTPrison.Infra {
    public sealed class PrisonDb : DbContext {
        public PrisonDb(DbContextOptions<PrisonDb> options) : base(options) { }
        public DbSet<PrisonerData>? Prisoners { get; internal set; }
        public DbSet<CellData>? Cells { get; internal set; }
        public DbSet<CountryData>? Countries { get; internal set; }
        public DbSet<CurrencyData>? Currencies { get; internal set; }
        public DbSet<PrisonerCellData>? PrisonerCells { get; internal set; }
        public DbSet<CountryCurrencyData>? CountryCurrencies { get; internal set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            var schema = nameof(PrisonDb)[0..^2];
            _ = (b?.Entity<PrisonerData>()?.ToTable(nameof(Prisoners), schema));
            _ = (b?.Entity<CellData>()?.ToTable(nameof(Cells), schema));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), schema));
            _ = (b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), schema));
            _ = (b?.Entity<PrisonerCellData>()?.ToTable(nameof(PrisonerCells), schema));
            _ = (b?.Entity<CountryCurrencyData>()?.ToTable(nameof(CountryCurrencies), schema));
        }
    }
}

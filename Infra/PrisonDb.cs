using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;

namespace MTPrison.Infra {
    public sealed class PrisonDb : DbContext {
        public PrisonDb(DbContextOptions<PrisonDb> options) : base(options) { }
        public DbSet<PrisonerData>? Prisoners { get; set; }
        public DbSet<CellData>? Cells { get; set; }
        public DbSet<CountryData>? Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            var schema = nameof(PrisonDb)[0..^2];
            _ = (b?.Entity<PrisonerData>()?.ToTable(nameof(Prisoners), schema));
            _ = (b?.Entity<CellData>()?.ToTable(nameof(Cells), schema));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), schema));
        }
    }
}

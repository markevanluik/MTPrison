using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;

namespace MTPrison.Infra {
    public sealed class PrisonDb : DbContext {
        public PrisonDb(DbContextOptions<PrisonDb> options) : base(options) { }
        public DbSet<PrisonerData> Prisoners { get; set; }
        public DbSet<CellData> Cells { get; set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            b?.Entity<PrisonerData>()?.ToTable(nameof(Prisoners), nameof(PrisonDb).Substring(0, 6));
            b?.Entity<CellData>()?.ToTable(nameof(Cells), nameof(PrisonDb).Substring(0, 6));
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTPrison.Infra;

namespace MTPrisonApp.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            initializeTables(b);
        }
        private static void initializeTables(ModelBuilder b) {
            PrisonDb.InitializeTables(b);
        }
    }
}

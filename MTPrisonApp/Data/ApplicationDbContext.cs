using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTPrisonApp.Data;

namespace MTPrisonApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MTPrisonApp.Data.Prisoner> Prisoner { get; set; }
        public DbSet<MTPrisonApp.Data.PrisonCell> PrisonCell { get; set; }
    }
}
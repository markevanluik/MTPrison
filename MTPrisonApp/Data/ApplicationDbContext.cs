using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrisonApp.Models;

namespace MTPrisonApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PrisonerData> Prisoners { get; set; }
        public DbSet<PrisonCellData> PrisonCells { get; set; }
    }
}
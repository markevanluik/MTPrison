using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(DbContext c, DbSet<CellData> s) : base(c, s) { }
        protected override Cell toDomain(CellData d) => new Cell(d);
    }
}

using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(PrisonDb? db) : base(db, db?.Cells) { }
        protected override Cell toDomain(CellData d) => new(d);
    }
}

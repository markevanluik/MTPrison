using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public sealed class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(PrisonDb? db) : base(db, db?.Cells) { }
        protected internal override Cell toDomain(CellData d) => new(d);
        internal override IQueryable<CellData> addFilter(IQueryable<CellData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.CellNumber.ToString().Contains(y)
                  || x.Section.Contains(y)
                  || x.Capacity.ToString().Contains(y));
        }
    }
}

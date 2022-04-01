using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(PrisonDb? db) : base(db, db?.Cells) { }
        protected override Cell toDomain(CellData d) => new(d);

        internal override IQueryable<CellData> addFilter(IQueryable<CellData> query) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return query;
            return query.Where(
                x => x.CellNumber.ToString().Contains(y)
                  || x.Capacity.ToString().Contains(y)
                  || x.Type.Contains(y)
                  || x.Section.Contains(y));
        }
    }
}

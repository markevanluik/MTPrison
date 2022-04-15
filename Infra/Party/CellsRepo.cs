using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(PrisonDb? db) : base(db, db?.Cells) { }
        protected override Cell toDomain(CellData d) => new(d);
        internal override IQueryable<CellData> addFilter(IQueryable<CellData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.CellNumber.ToString().Contains(y)
                  || x.Capacity.ToString().Contains(y)
                  || x.Type.ToString().Contains(y)
                  || x.Section.Contains(y)
                  || x.CountryId.Contains(y)
                  || x.Inspection.ToString().Contains(y));
        }
    }
}

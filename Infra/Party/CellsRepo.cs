using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class CellsRepo : Repo<Cell, CellData>, ICellsRepo {
        public CellsRepo(PrisonDb? db) : base(db, db?.Cells) { }
        protected override Cell toDomain(CellData d) => new(d);

        internal override IQueryable<CellData> addFilter(IQueryable<CellData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => contains(x.CellNumber.ToString(), y)
                  || contains(x.Capacity.ToString(), y)
                  || contains(x.Type, y)
                  || contains(x.Section, y)
                  || contains(x.Country, y)
                  || contains(x.Inspection.ToString(), y)
                  || contains(x.Gender.ToString(), y));
        }
    }
}

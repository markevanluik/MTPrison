using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Infra.Party {
    public class PrisonerCellsRepo : Repo<PrisonerCell, PrisonerCellData>, IPrisonerCellsRepo {
        public PrisonerCellsRepo(PrisonDb? db) : base(db, db?.PrisonerCells) { }
        protected override PrisonerCell toDomain(PrisonerCellData d) => new(d);
        internal override IQueryable<PrisonerCellData> addFilter(IQueryable<PrisonerCellData> query) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? query : query.Where(
                x => x.Id.Contains(y)
                  || x.PrisonerId.Contains(y)
                  || x.CellId.Contains(y)
                  || x.Code.Contains(y)
                  || x.Name.Contains(y)
                  || x.NativeName.Contains(y));
        }
    }
}

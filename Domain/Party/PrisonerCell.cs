using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {

    public interface IPrisonerCellsRepo : IRepo<PrisonerCell> { }
    public sealed class PrisonerCell : NamedEntity<PrisonerCellData> {

        public PrisonerCell() : this(new()) { }
        public PrisonerCell(PrisonerCellData d) : base(d) { }

        public string PrisonerId => getValue(Data?.PrisonerId);
        public string CellId => getValue(Data?.CellId);

        public Prisoner? Prisoner => GetRepo.Instance<IPrisonersRepo>()?.Get(PrisonerId);
        public Cell? Cell => GetRepo.Instance<ICellsRepo>()?.Get(CellId);
    }
}

using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICellsRepo : IRepo<Cell> { }
    public sealed class Cell : UniqueEntity<CellData>{
        public Cell() : this(new()) { }
        public Cell(CellData d) : base(d) { }
        public int CellNumber => getValue(Data?.CellNumber);
        public string? Section => getValue(Data?.Section);
        public int Capacity => getValue(Data?.Capacity);
        public CellType? Type => getValue(Data?.Type);

        public List<PrisonerCell> PrisonerCells
            => GetRepo.Instance<IPrisonerCellsRepo>()?
            .GetAll(x => x.CellId)?
            .Where(x => x.CellId == Id)?
            .ToList() ?? new List<PrisonerCell>();

        public List<Prisoner?> Prisoners
            => PrisonerCells
            .Select(x => x.Prisoner)
            .ToList() ?? new List<Prisoner?>();
    }
}

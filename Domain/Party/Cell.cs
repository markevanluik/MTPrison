using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICellsRepo : IRepo<Cell> { }
    public sealed class Cell : UniqueEntity<CellData>{
        public Cell() : this(new()) { }
        public Cell(CellData d) : base(d) { }
        public int CellNumber => getValue(Data?.CellNumber);
        public int Capacity => getValue(Data?.Capacity);
        public CellType? Type => getValue(Data?.Type);
        public string? Section => getValue(Data?.Section);
        public string? Country => getValue(Data?.CountryId);
        public DateTime? Inspection => getValue(Data?.Inspection);

        //public List<Prisoner> Occupants { get; set; }
    }
}

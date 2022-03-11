using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICellsRepo : IRepo<Cell> { }
    public class Cell : Entity<CellData>{
        public Cell() : this(new CellData()) { }
        public Cell(CellData d) : base(d) { }
        public int CellNumber => getValue(Data?.CellNumber);
        public int Capacity => getValue(Data?.Capacity);
        public string? Type => getValue(Data?.Type);
        public string? Section => getValue(Data?.Section);

        //public List<Prisoner> Occupants { get; set; }
    }
}

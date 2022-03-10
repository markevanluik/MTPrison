using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface ICellsRepo : IRepo<Cell> { }
    public class Cell : Entity<CellData>{
        public Cell() : this(new CellData()) { }
        public Cell(CellData d) : base(d) { }
        public int CellNumber => Data?.CellNumber ?? defaultInt;
        public int Capacity => Data?.Capacity ?? defaultInt;
        public string? Type => Data?.Type ?? defaultStr;
        public string? Section => Data?.Section ?? defaultStr;

        //public List<Prisoner> Occupants { get; set; }
    }
}

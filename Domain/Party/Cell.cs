using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public class Cell : Entity<CellData>{
        private const string defaultStr = "Undefined";
        private const int defaultInt = int.MinValue;
        public Cell() : this(new CellData()) { }
        public Cell(CellData d) : base(d) { }
        public string Id => Data?.Id ?? defaultStr;
        public int CellNumber => Data?.CellNumber ?? defaultInt;
        public int Capacity => Data?.Capacity ?? defaultInt;
        public string? Type => Data?.Type ?? defaultStr;
        public string? Section => Data?.Section ?? defaultStr;

        //public List<Prisoner> Occupants { get; set; }
    }
}

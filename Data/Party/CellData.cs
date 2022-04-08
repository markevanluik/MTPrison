
namespace MTPrison.Data.Party {
    public sealed class CellData : UniqueData {
        public int CellNumber { get; set; }
        public int Capacity { get; set; }
        public string? Type { get; set; }
        public string? Section { get; set; }
        public string? Country { get; set; }
        public DateTime? Inspection { get; set; }
        public IsoGender? Gender { get; set; }


        //public List<Prisoner> Occupants { get; set; }
    }
}

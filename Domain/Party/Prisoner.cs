using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface IPrisonersRepo : IRepo<Prisoner> { }
    public sealed class Prisoner : UniqueEntity<PrisonerData> {
        public Prisoner() : this(new PrisonerData()) { }
        public Prisoner(PrisonerData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public DateTime DoB => getValue(Data?.DoB);
        public string Offense => getValue(Data?.Offense);
        public DateTime DateOfImprisonment => getValue(Data?.DateOfImprisonment);
        public DateTime DateOfRelease => getValue(Data?.DateOfRelease);
        public string FullName => $"{FirstName} {LastName}";

        public Lazy<List<PrisonerCell>> PrisonerCells {
            get {
                var l = GetRepo.Instance<IPrisonerCellsRepo>()?
                    .GetAll(x => x.PrisonerId)?
                    .Where(x => x.PrisonerId == Id)?
                    .ToList() ?? new List<PrisonerCell>();
                return new Lazy<List<PrisonerCell>>(l);
            }
        }
        public Lazy<List<Cell?>> Cells {
            get {
                var l = PrisonerCells.Value
                    .Select(x => x.Cell)
                    .ToList() ?? new List<Cell?>();
                return new Lazy<List<Cell?>>(l);
            }
        }
    }
}

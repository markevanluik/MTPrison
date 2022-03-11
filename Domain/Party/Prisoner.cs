using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public interface IPrisonersRepo : IRepo<Prisoner> { }
    public class Prisoner : Entity<PrisonerData> {
        public Prisoner() : this(new PrisonerData()) { }
        public Prisoner(PrisonerData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string Offense => getValue(Data?.Offense);
        public DateTime DoB => getValue(Data?.DoB);
        public DateTime DateOfRelease => getValue(Data?.DateOfRelease);
        public DateTime DateOfImprisonment => getValue(Data?.DateOfImprisonment);
        public string Fullname() => $"{FirstName} {LastName}";
    }
}

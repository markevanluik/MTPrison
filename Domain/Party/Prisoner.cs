using MTPrison.Data.Party;

namespace MTPrison.Domain.Party {
    public class Prisoner : Entity<PrisonerData> {
        private const string defaultStr = "Undefined";
        private DateTime defaultDate => DateTime.MinValue;

        public Prisoner() : this(new PrisonerData()) { }
        public Prisoner(PrisonerData d) : base(d) { }
        public string Id => Data?.Id ?? defaultStr;
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public string Offense => Data?.Offense ?? defaultStr;
        public DateTime DoB => Data?.DoB ?? defaultDate;
        public DateTime DateOfRelease => Data?.DateOfRelease ?? defaultDate;
        public DateTime DateOfImprisonment => Data?.DateOfImprisonment ?? defaultDate;

        public string Fullname() => $"{FirstName} {LastName}";
    }
}

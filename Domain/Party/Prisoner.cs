using MTPrison.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Domain.Party
{
    public class Prisoner
    {
        private const string defaultStr = "Undefined";
        private DateTime defaultDate => DateTime.MinValue;
        private PrisonerData data;
        public Prisoner() : this(new PrisonerData()) { }
        public Prisoner(PrisonerData d) => data = d;
        public string Id => data?.Id ?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName => data?.LastName ?? defaultStr;
        public string Offense => data?.Offense ?? defaultStr;
        public DateTime DoB => data?.DoB ?? defaultDate;
        public DateTime DateOfRelease => data?.DateOfRelease ?? defaultDate;
        public DateTime DateOfImprisonment => data?.DateOfImprisonment ?? defaultDate;
        public PrisonerData Data => data;
        public string Fullname() => $"{FirstName} {LastName}";
    }
}

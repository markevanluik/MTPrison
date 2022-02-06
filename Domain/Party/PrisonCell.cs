using MTPrison.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Domain.Party
{
    public class PrisonCell
    {
        private const string defaultStr = "Undefined";
        private const int defaultInt = int.MinValue;
        private PrisonCellData data;
        public PrisonCell() : this(new PrisonCellData()) { }
        public PrisonCell(PrisonCellData d) => data = d;
        public string Id => data?.Id ?? defaultStr;
        public int CellNumber => data?.CellNumber ?? defaultInt;
        public int Capacity => data?.Capacity ?? defaultInt;
        public string? Type => data?.Type ?? defaultStr;
        public string? Section => data?.Section ?? defaultStr;
        public PrisonCellData Data => data;

        //public List<Prisoner> Occupants { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Data.Party
{
    public class PrisonCellData
    {
        public string Id { get; set; }
        public int CellNumber { get; set; }
        public int Capacity { get; set; }
        public string? Type { get; set; }
        public string? Section { get; set; }

        //public List<Prisoner> Occupants { get; set; }
    }
}

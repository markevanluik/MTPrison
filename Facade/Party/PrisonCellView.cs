using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Facade.Party
{
    public class PrisonCellView
    {
        [Required] public string Id { get; set; }
        [Display(Name = "Cell Number")] [Range(1, 10000)] public int CellNumber { get; set; }
        [Display(Name = "Capacity")] [Range(1, 1000)] public int Capacity { get; set; }
        [Display(Name = "Type")] [Required] public string? Type { get; set; }
        [Display(Name = "Section")] [Required] public string? Section { get; set; }

        //public List<Prisoner> Occupants { get; set; }
    }
}

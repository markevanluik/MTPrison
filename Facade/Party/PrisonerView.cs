using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Facade.Party
{
    public class PrisonerView
    {
        [Required] public string Id { get; set; }
        [Display(Name = "First Name")] [Required] public string? FirstName { get; set; }
        [Display(Name = "Last Name")] [Required] public string? LastName { get; set; }
        [Display(Name = "Offense")] [Required] public string? Offense { get; set; }
        [Display(Name = "Birth Date")] [DataType(DataType.Date)] public DateTime DoB { get; set; }
        [Display(Name = "Date Of Release")] [DataType(DataType.Date)] public DateTime DateOfRelease { get; set; }
        [Display(Name = "Date Of Imprisonment")] [DataType(DataType.Date)] public DateTime DateOfImprisonment { get; set; }
        [Display(Name = "Full Name")] public string? FullName { get; set; }

        //[Display(Name = "Prison Cell")] [Required] public string PrisonCell { get; set; }
    }
}

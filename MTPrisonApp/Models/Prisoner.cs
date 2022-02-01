using System.ComponentModel.DataAnnotations;

namespace MTPrisonApp.Data
{
    public class Prisoner
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        public string? Offense { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime DoB { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Release")]
        public DateTime DateOfRelease { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Imprisonment")]
        public DateTime DateOfImprisonment { get; set; }

        //public string PrisonCell { get; set; }
    }
}

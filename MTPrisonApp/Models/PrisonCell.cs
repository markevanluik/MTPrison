using System.ComponentModel.DataAnnotations;

namespace MTPrisonApp.Models
{
    public class PrisonCell
    {
        public string Id { get; set; }

        [Display(Name = "Cell Number")]
        [Range(1, 10000)]
        public int CellNumber { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Section { get; set; }

        //public List<Prisoner> Occupants { get; set; }
    }
}

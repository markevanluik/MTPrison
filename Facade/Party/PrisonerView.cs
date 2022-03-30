using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public sealed class PrisonerView : UniqueView {
        [Display(Name = "First Name")] [Required] public string? FirstName { get; set; }
        [Display(Name = "Last Name")] [Required] public string? LastName { get; set; }
        [Display(Name = "Offense")] [Required] public string? Offense { get; set; }
        [Display(Name = "Birth Date")] [DataType(DataType.Date)] public DateTime DoB { get; set; }
        [Display(Name = "Date Of Release")] [DataType(DataType.Date)] public DateTime DateOfRelease { get; set; }
        [Display(Name = "Date Of Imprisonment")] [DataType(DataType.Date)] public DateTime DateOfImprisonment { get; set; }
        [Display(Name = "Full Name")] public string? FullName { get; set; }

        //[Display(Name = "Prison Cell")] [Required] public string PrisonCell { get; set; }
    }
    public sealed class PrisonerViewFactory : BaseViewFactory<PrisonerView, Prisoner, PrisonerData> {
        protected override Prisoner toEntity(PrisonerData d) => new(d);
        public override PrisonerView Create(Prisoner? e) {
            var v = base.Create(e);
            v.FullName = e?.FullName();
            return v;
        }

    }
}

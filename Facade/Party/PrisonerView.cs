using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade.Party {
    public sealed class PrisonerView : UniqueView {
        [Required, DisplayName("First Name")] public string? FirstName { get; set; }
        [Required, DisplayName("Last Name")] public string? LastName { get; set; }
        [Required, DisplayName("Offense")] public string? Offense { get; set; }
        [DisplayName("Birth Date"), DataType(DataType.Date)] public DateTime DoB { get; set; }
        [DisplayName("Date Of Release"), DataType(DataType.Date)] public DateTime DateOfRelease { get; set; }
        [DisplayName("Date Of Imprisonment"), DataType(DataType.Date)] public DateTime DateOfImprisonment { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
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

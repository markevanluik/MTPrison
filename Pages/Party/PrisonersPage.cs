using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public class PrisonersPage : PagedPage<PrisonerView, Prisoner, IPrisonersRepo> {
        public PrisonersPage(IPrisonersRepo r) : base(r) { }
        protected override Prisoner toObject(PrisonerView? item) => new PrisonerViewFactory().Create(item);
        protected override PrisonerView toView(Prisoner? entity) => new PrisonerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PrisonerView.Id),
            nameof(PrisonerView.FullName),
            nameof(PrisonerView.FirstName),
            nameof(PrisonerView.LastName),
            nameof(PrisonerView.Offense),
            nameof(PrisonerView.DoB),
            nameof(PrisonerView.DateOfImprisonment),
            nameof(PrisonerView.DateOfRelease),
        };
    }
}




using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages {
    public class PrisonersPage : BasePage<PrisonerView, Prisoner, IPrisonersRepo> {
        public PrisonersPage(IPrisonersRepo r) : base(r) { }
        protected override Prisoner toObject(PrisonerView item) => new PrisonerViewFactory().Create(item);
        protected override PrisonerView toView(Prisoner entity) => new PrisonerViewFactory().Create(entity);
    }
}




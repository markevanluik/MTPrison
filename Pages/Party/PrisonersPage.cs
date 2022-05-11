using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class PrisonersPage : PagedPage<PrisonerView, Prisoner, IPrisonersRepo> {
        public PrisonersPage(IPrisonersRepo r) : base(r) { }
        protected override Prisoner toObject(PrisonerView? item) => new PrisonerViewFactory().Create(item);
        protected override PrisonerView toView(Prisoner? entity) => new PrisonerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PrisonerView.FullName),
            nameof(PrisonerView.Offense),
            nameof(PrisonerView.DoB),
            nameof(PrisonerView.DateOfImprisonment),
            nameof(PrisonerView.DateOfRelease),
        };

        // avoid static at the moment
        public string ShortDate(DateTime? date) => (date ?? DateTime.MinValue).ToShortDateString();
        public override object? GetValue(string name, PrisonerView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.DoB) ? ShortDate((DateTime?)r)
                 : name == nameof(v.DateOfImprisonment) ? ShortDate((DateTime?)r)
                 : name == nameof(v.DateOfRelease) ? ShortDate((DateTime?)r)
                 : r;
        }

        // this is only for Prisoner Details showing cells
        public Lazy<List<Cell?>> Cells => toObject(Item).Cells;
    }
}

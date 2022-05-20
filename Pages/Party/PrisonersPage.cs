using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class PrisonersPage : PagedPage<PrisonerView, Prisoner, IPrisonersRepo> {
        public PrisonersPage(IPrisonersRepo r) : base(r) { }
        protected override Prisoner toObject(PrisonerView? item) => new PrisonerViewFactory().Create(item);
        protected override PrisonerView toView(Prisoner? entity) => new PrisonerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PrisonerView.FullName),
            nameof(PrisonerView.DoB),
            nameof(PrisonerView.Offense),
            nameof(PrisonerView.DateOfImprisonment),
            nameof(PrisonerView.DateOfRelease),
        };

        public string ShortDate(DateTime? date) => (date ?? DateTime.MinValue).ToShortDateString();
        public override object? GetValue(string name, PrisonerView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.DoB) ? ShortDate((DateTime?)r)
                 : name == nameof(v.DateOfImprisonment) ? ShortDate((DateTime?)r)
                 : name == nameof(v.DateOfRelease) ? ShortDate((DateTime?)r)
                 : r;
        }

        public Lazy<List<Cell?>> Cells => toObject(Item).Cells;
    }
}

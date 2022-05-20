using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public sealed class PrisonersPage : PagedPage<PrisonerView, Prisoner, IPrisonersRepo> {
        private readonly ICountriesRepo countries;
        public PrisonersPage(IPrisonersRepo r, ICountriesRepo c) : base(r) => countries = c;

        protected override Prisoner toObject(PrisonerView? item) => new PrisonerViewFactory().Create(item);
        protected override PrisonerView toView(Prisoner? entity) => new PrisonerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PrisonerView.FullName),
            nameof(PrisonerView.SSN),
            nameof(PrisonerView.Country),
            nameof(PrisonerView.Offense),
            nameof(PrisonerView.DateOfImprisonment),
            nameof(PrisonerView.DateOfRelease),
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll()?
            .Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";
        public string ShortDate(DateTime? date) => (date ?? DateTime.MinValue).ToShortDateString();

        public override object? GetValue(string name, PrisonerView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.Country) ? CountryName(r as string)
                 : name == nameof(v.DateOfImprisonment) ? ShortDate((DateTime?)r)
                 : name == nameof(v.DateOfRelease) ? ShortDate((DateTime?)r)
                 : r;
        }
        public Lazy<List<Cell?>> Cells => toObject(Item).Cells;
    }
}

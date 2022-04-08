using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Pages.Party {
    public class CellsPage : PagedPage<CellView, Cell, ICellsRepo> {
        private readonly ICountriesRepo countries;
        public CellsPage(ICellsRepo r, ICountriesRepo c) : base(r) => countries = c;
        protected override Cell toObject(CellView? item) => new CellViewFactory().Create(item);
        protected override CellView toView(Cell? entity) => new CellViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CellView.CellNumber),
            nameof(CellView.Capacity),
            nameof(CellView.Type),
            nameof(CellView.Section),
            nameof(CellView.Country),
            nameof(CellView.Inspection),
            nameof(CellView.Gender)
        };
        public override object? GetValue(string name, CellView v) {
            var r = base.GetValue(name, v);
            return name switch {
                nameof(v.Inspection) => name is nameof(v.Inspection) ? ShortDate((DateTime)r) : r,
                nameof(v.Gender) => name is nameof(v.Gender) ? GenderDescription((IsoGender)r) : r,
                _ => name is nameof(v.Country) ? CountryName(r as string) : r
            };
        }

        // avoid static at the moment, @_view...gets too long
        public string ShortDate(DateTime? date) => (date ?? DateTime.MinValue).ToShortDateString();
        public string GenderDescription(IsoGender? g) => (g ?? IsoGender.NotApplicable).Description();
        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";

        public IEnumerable<SelectListItem> Genders => Enum.GetValues<IsoGender>()
            .Select(g => new SelectListItem(g.Description(), g.ToString())) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Countries
            => countries.GetAll<string>()?.Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
    }
}

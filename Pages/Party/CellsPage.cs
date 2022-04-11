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
            nameof(CellView.CountryId),
            nameof(CellView.Inspection),
            nameof(CellView.Gender)
        };
        // avoid static at the moment
        public IEnumerable<SelectListItem> Countries
            => countries.GetAll<string>()?.Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Genders => Enum.GetValues<IsoGender>()
            .Select(g => new SelectListItem(g.Description(), g.ToString())) ?? new List<SelectListItem>();

        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Unspecified";
        public string ShortDate(DateTime? date) => (date ?? DateTime.MinValue).ToShortDateString();
        public string GenderDescription(IsoGender? g) => (g ?? IsoGender.NotApplicable).Description();

        public override object? GetValue(string name, CellView v) {
            var r = base.GetValue(name, v);
            return name == nameof(v.CountryId) ? CountryName(r as string)
                 : name == nameof(v.Inspection) ? ShortDate((DateTime)r)
                 : name == nameof(v.Gender) ? GenderDescription((IsoGender)r)
                 : r;
        }
    }
}

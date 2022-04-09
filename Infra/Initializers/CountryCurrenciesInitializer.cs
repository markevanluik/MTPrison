using MTPrison.Data.Party;
using System.Globalization;

namespace MTPrison.Infra.Initializers {
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
        public CountryCurrenciesInitializer(PrisonDb? db) : base(db, db?.CountryCurrencies) { }

        protected override IEnumerable<CountryCurrencyData> getEntities {
            get {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ThreeLetterISORegionName;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                    var data = createCountry(id, id, c.ISOCurrencySymbol, c.ISOCurrencySymbol, c.CurrencySymbol, c.CurrencyNativeName);
                    l.Add(data);
                }
                return l;
            }
        }
        internal static CountryCurrencyData createCountry(string id, string coId, string cuId, string code, string name, string nativeName) => new() {
            Id = id,
            CountryId = coId,
            CurrencyId = cuId,
            Code = code,
            Name = name,
            NativeName = nativeName
        };
    }
}
